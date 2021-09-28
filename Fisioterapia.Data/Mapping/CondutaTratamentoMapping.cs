using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class CondutaTratamentoMapping : IEntityTypeConfiguration<CondutaTratamento>
    {
        public void Configure(EntityTypeBuilder<CondutaTratamento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CondutaId)
                .IsRequired();

            builder.Property(a => a.TratamentoId)
                .IsRequired();

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder
                .HasOne(a => a.Tratamento)
                .WithMany(a => a.CondutaTratamentos)
                .HasForeignKey(a => a.TratamentoId);

            builder
                .HasOne(a => a.Conduta)
                .WithMany(a => a.CondutaTratamentos)
                .HasForeignKey(a => a.CondutaId);

            builder.ToTable("CondutaTratamento");
        }
    }
}
