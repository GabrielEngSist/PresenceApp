using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presence.API.Services;

namespace Presence.API.Installers
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPresencaService, PresencaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IInstituicaoService, InstituicaoService>();
            services.AddScoped<IUsuarioStrategy, UsuarioStrategy>();
            services.AddScoped<IClasseService, ClasseService>();
            services.AddScoped<IChamadaService, ChamadaService>();
        }
    }
}
