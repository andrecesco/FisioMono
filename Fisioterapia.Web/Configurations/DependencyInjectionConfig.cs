using Fisioterapia.Core.Mediator;
using Fisioterapia.Core.Messages.IntegrationEvents;
using Fisioterapia.Data;
using Fisioterapia.Data.Repository;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Notificacoes;
using Fisioterapia.Domain.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Fisioterapia.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<FisioterapiaDbContext>();
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<ICondutaRepository, CondutaRepository>();
            services.AddScoped<IAnamneseRepository, AnamneseRepository>();
            services.AddScoped<IConvenioRepository, ConvenioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICondutaTratamentoRepository, CondutaTratamentoRepository>();
            services.AddScoped<ITratamentoRepository, TratamentoRepository>();

            services.AddScoped<INotificationHandler<PacienteRemovidoEvent>, PacienteHandler>();

            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<ICondutaService, CondutaService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
