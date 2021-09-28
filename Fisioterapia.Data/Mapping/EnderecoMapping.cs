using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.PacienteId)
                .IsRequired();

            builder.Property(a => a.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(a => a.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Complemento)
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.CEP)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder.HasOne(a => a.Paciente)
                .WithMany(a => a.Enderecos)
                .HasForeignKey(a => a.PacienteId);

            builder.ToTable("Endereco");
        }
    }
}

