using FormClean.Application.Interfaces;
using FormClean.Application.Mappings;
using FormClean.Application.Services;
using FormClean.Domain.Interfaces;
using FormClean.Infra.Data.Context;
using FormClean.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormClean.Infra.IoC
{
    public static class DependencyInjection
    {

        const string ServiceName = "ConexaoBD";
        public static IServiceCollection AddInfraestructure(this IServiceCollection services,
            IConfiguration configuration) 
        {


            services.AddDbContext<ApplicationDbContext>(options 
                => options.UseSqlServer(configuration.GetConnectionString(ServiceName),
                migration 
                => migration.MigrationsAssembly
                (typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IDemandedRepository, DemandedRepository>();
            services.AddScoped<IDemandedService, DemandedService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
