using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class TratamentoMapping : IEntityTypeConfiguration<Tratamento>
    {
        public void Configure(EntityTypeBuilder<Tratamento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder
                .HasMany(a => a.CondutaTratamentos)
                .WithOne(a => a.Tratamento)
                .HasForeignKey(a => a.TratamentoId);

            builder.ToTable("Tratamentos");
        }
    }
}
