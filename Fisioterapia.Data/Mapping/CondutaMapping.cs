using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class CondutaMapping : IEntityTypeConfiguration<Conduta>
    {
        public void Configure(EntityTypeBuilder<Conduta> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.PacienteId)
                .IsRequired();

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder
                .HasMany(a => a.CondutaTratamentos)
                .WithOne(a => a.Conduta)
                .HasForeignKey(a => a.CondutaId);

            builder.ToTable("Conduta");
        }
    }
}
