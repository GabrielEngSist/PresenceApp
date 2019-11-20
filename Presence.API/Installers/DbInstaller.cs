using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presence.API.Data;
using Presence.API.Options.DatabaseConfig;

namespace Presence.API.Installers
{

    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = new DatabaseConfig();

            configuration.Bind(key: nameof(databaseConfig), databaseConfig);

            var connectionString = new DataBaseConfigFactory(databaseConfig)
                .ObterImplementacao();

            services.AddDbContext<DataContext>(
                    options => {
                        options.Use(connectionString);
                    }
                );
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();
        }
    }
}
