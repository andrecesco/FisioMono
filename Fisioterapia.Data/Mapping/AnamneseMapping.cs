using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fisioterapia.Data.Mapping
{
    public class AnamneseMapping : IEntityTypeConfiguration<Anamnese>
    {
        public void Configure(EntityTypeBuilder<Anamnese> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.PacienteId)
                .IsRequired();

            builder.Property(a => a.QP);

            builder.Property(a => a.Investigacao);

            builder.Property(a => a.HPM);

            builder.Property(a => a.PressaoAlta);

            builder.Property(a => a.MedicamentoParaPressao);

            builder.Property(a => a.PraticaAtividadeFisica);

            builder.Property(a => a.NomeAtividadeFisica);

            builder.Property(a => a.ExameFisioPostural);

            builder.Property(a => a.ConsumeSubstancias);

            builder.Property(a => a.AlgiaPalpacao);

            builder.Property(a => a.TonusMuscular);

            builder.Property(a => a.HipotrofiaMuscular);

            builder.Property(a => a.ContraturaMuscular);

            builder.Property(a => a.ContraturaMuscularObservacao);

            builder.Property(a => a.RetracaoMuscular);

            builder.Property(a => a.RetracaoMuscularObservacao);

            builder.Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataDelecao)
                .HasColumnType("datetime");

            builder.Property(a => a.DataAlteracao)
                .HasColumnType("datetime");

            builder.HasOne(a => a.Paciente)
                .WithOne(a => a.Anamnese);

            builder.ToTable("Anamneses");
        }
    }
}

