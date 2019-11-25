using System;

namespace Presence.API.Services
{
    public interface IInstituicaoService : IUsuarioService
    {
        void RecuperarInstituicaoPeloUserId(Guid instituicaoId);
    }
}