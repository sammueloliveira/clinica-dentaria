using Application.Interfaces;
using Application.OpenApp;
using Domain.Interfaces;
using Domain.InterfaceServices;
using Domain.Services;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HelpConfig.Startup
{
    public static class HelpStartup 
    {
        public static void ConfigureScoped(IServiceCollection services)
        {
            // INTERFACE E REPOSITORIO
            services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped<IDentista, RepositoryDentista>();
            services.AddScoped<IPaciente, RepositoryPaciente>();
            services.AddScoped<ITratamento, RepositoryTratamento>();

            // INTERFACE APLICAÇAO
            services.AddScoped<IDentistaApp, DentistaApp>();
            services.AddScoped<IPacienteApp, PacienteApp>();
            services.AddScoped<ItratamentoApp, TratamentoApp>();

            // SERVIÇO DOMINIO
            services.AddScoped<IServiceDentista, ServiceDentista>();
            services.AddScoped<IServicePaciente, ServicePaciente>();
            services.AddScoped<IServiceTratamento, ServiceTratamento>();
        }
    }
}
