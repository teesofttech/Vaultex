using Vaultex.Application.Repositories;
using Vaultex.Persistence.Context;
using Vaultex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vaultex.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();

            return services;
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VaultexContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("VaultexContext"),
                   b => b.MigrationsAssembly(typeof(VaultexContext).Assembly.FullName)), ServiceLifetime.Scoped);

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IOrganisationRepository, OrganisationRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
