using System.Linq;
using System.Threading.Tasks;
using fullstackdotnet.domain;
using Microsoft.EntityFrameworkCore;

namespace fullstackdotnet.repository
{
    public class FullstackRepository : IFullstackRepository
    {
        private FullstackDataContext _dbContext;

        public FullstackRepository(FullstackDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // -----------------------------------------------------
        // GERAL
        // -----------------------------------------------------

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        // -----------------------------------------------------
        // EVENTOS
        // -----------------------------------------------------
        public async Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _dbContext.Eventos
            .Include(c=>c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p=>p.Palestrante);
            }

            query.OrderByDescending(e => e.DataEvento)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _dbContext.Eventos
            .Include(c=>c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p=>p.Palestrante);
            }

            query.OrderByDescending(e => e.DataEvento)
                .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _dbContext.Eventos
            .Include(c=>c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p=>p.Palestrante);
            }

            query.OrderByDescending(e => e.DataEvento);

            return await query.ToArrayAsync();
        }
        
        // -----------------------------------------------------
        // PALESTRANTES
        // -----------------------------------------------------
        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _dbContext.Palestrantes
            .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            query.OrderBy(e => e.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _dbContext.Palestrantes
                .Include(p => p.RedesSociais);

            if(includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _dbContext.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e=>e.Evento);
            }

            query.OrderBy(p => p.Nome)
                .Where(e => e.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        // -----------------------------------------------------
        // SALVAMENTO DOS DADOS
        // -----------------------------------------------------
        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() > 0);
        }        
    }
}