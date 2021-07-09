using fullstackdotnet.domain;
using Microsoft.EntityFrameworkCore;

namespace fullstackdotnet.repository
{
    public class FullstackDataContext : DbContext
    {
        public FullstackDataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PalestranteEvento>()
            .HasKey(pe => new { pe.EventoId, pe.PalestranteId });

            builder.ApplyConfigurationsFromAssembly(typeof(FullstackDataContext).Assembly);
        }
    }
}