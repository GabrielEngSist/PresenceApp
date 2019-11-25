using Presence.API.Contracts.V1.Requests;

namespace Presence.API.Services
{
    public interface IUsuarioStrategy
    {
        IUsuarioService RecuperarEstrategia(UserRegistrationRequest usuario);
    }
}
