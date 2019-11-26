using Microsoft.AspNetCore.Identity;
using Presence.API.Contracts.V1.Requests;
using Presence.API.Domain;
using System.Threading.Tasks;

namespace Presence.API.Services
{

    public interface IIdentityService
    {     
        Task<AuthenticationResult> RegistrarAsync(UserRegistrationRequest user);

        Task<AuthenticationResult> LoginAsync(string email, string senha);
        
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<IdentityUser> ObterUsuarioPorEmailAsync(string email);
    }
}
