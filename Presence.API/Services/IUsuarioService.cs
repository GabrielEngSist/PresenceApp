using Presence.API.Contracts.V1.Requests;
using System;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public interface IUsuarioService
    {
        Task CriarUsuarioAsync(Guid UserId, UserRegistrationRequest usuario);
    }
}
