using fullstackdotnet.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fullstackdotnet.repository.Mapping
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(p => p.Local)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.Property(p => p.Tema)
            .IsRequired()
            .HasColumnType("varchar(50)");

            builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnType("varchar(50)");

            builder.Property(p => p.Telefone)
            .IsRequired()
            .HasColumnType("varchar(11)");

            builder.ToTable("Eventos");
        }
    }
}