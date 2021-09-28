using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Documento)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(a => a.NomeCompleto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Email)
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(a => a.Celular)
                .HasColumnType("varchar(20)");

            builder.Property(a => a.DataNascimento)
                .HasColumnType("datetime");

            builder.Property(a => a.Profissao)
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder
                .HasOne(a => a.Anamnese)
                .WithOne(a => a.Paciente);

            builder
                .HasMany(a => a.Enderecos)
                .WithOne(a => a.Paciente)
                .HasForeignKey(a => a.PacienteId);

            builder
                .HasMany(a => a.Condutas)
                .WithOne(a => a.Paciente)
                .HasForeignKey(a => a.PacienteId);

            builder
                .HasMany(a => a.Convenios)
                .WithOne(a => a.Paciente)
                .HasForeignKey(a => a.PacienteId);

            builder.ToTable("Paciente");
        }
    }
}

