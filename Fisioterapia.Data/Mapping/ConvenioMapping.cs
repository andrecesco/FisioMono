using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class ConvenioMapping : IEntityTypeConfiguration<Convenio>
    {
        public void Configure(EntityTypeBuilder<Convenio> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Matricula);

            builder.Property(a => a.Nome)
                .IsRequired();

            builder.Property(a => a.Ativo)
                .IsRequired();

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder.HasOne(a => a.Paciente)
                .WithMany(a => a.Convenios)
                .HasForeignKey(a => a.PacienteId);

            builder.ToTable("Convenios");
        }
    }
}
