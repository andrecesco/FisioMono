using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Models.Old;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fisioterapia.Data
{
    public class FisioterapiaDbContext : DbContext
    {
        public DbSet<Anamnese> Anamneses { get; set; }
        public DbSet<Conduta> Condutas { get; set; }
        public DbSet<CondutaTratamento> CondutasTratamentos { get; set; }
        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<PacienteOld> Paciente { get; set; }
        public DbSet<ExameCondutaOld> Exame_Conduta { get; set; }
        public DbSet<ConfiguracaoOld> Configuracao { get; set; }

        public FisioterapiaDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Entity<Anamnese>().HasQueryFilter(c => c.DataDelecao == null);
            modelBuilder.Entity<Conduta>().HasQueryFilter(c => c.DataDelecao == null);
            modelBuilder.Entity<CondutaTratamento>().HasQueryFilter(c => c.DataDelecao == null);
            modelBuilder.Entity<Convenio>().HasQueryFilter(c => c.DataDelecao == null);
            modelBuilder.Entity<Endereco>().HasQueryFilter(c => c.DataDelecao == null);
            modelBuilder.Entity<Paciente>().HasQueryFilter(c => c.DataDelecao == null);
            modelBuilder.Entity<Tratamento>().HasQueryFilter(c => c.DataDelecao == null);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FisioterapiaDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAlteracao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
