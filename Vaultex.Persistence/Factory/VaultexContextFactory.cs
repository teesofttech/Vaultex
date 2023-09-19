using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vaultex.Persistence.Context;
using Vaultex.Persistence.Extensions;

namespace Vaultex.Persistence.Factory
{
    public class VaultexContextFactory : IDesignTimeDbContextFactory<VaultexContext>
    {
        public VaultexContext CreateDbContext(string[] args)
        {
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .AddBasePath()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<VaultexContext>();
            var connectionString = config.GetConnectionString(nameof(VaultexContext));
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Vaultex.Persistence"));
            return new VaultexContext(optionsBuilder.Options);
        }
    }
}
