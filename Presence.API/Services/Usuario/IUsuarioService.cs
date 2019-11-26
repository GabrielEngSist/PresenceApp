using Presence.API.Contracts.V1.Requests;
using Presence.API.Domain.Enum;
using System;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public interface IUsuarioService
    {
        Task<TipoUsuario> CriarUsuarioAsync(Guid UserId, UserRegistrationRequest usuario);
    }
}
