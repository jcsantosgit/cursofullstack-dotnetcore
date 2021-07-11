using System.Threading.Tasks;
using fullstackdotnet.domain;

namespace fullstackdotnet.repository
{
    public interface IFullstackRepository
    {
        //------------------------------------
        // Geral
        //------------------------------------        
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();

        //------------------------------------
        // Eventos
        //------------------------------------
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoById(int id, bool includePalestrantes = false);   

        //------------------------------------
        // Palestrante
        //------------------------------------
        Task<Palestrante[]> GetAllEventoAsyncByNome(string nome, bool includePalestrantes = false);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteById(int id, bool includeEventos = false);      
    }
}