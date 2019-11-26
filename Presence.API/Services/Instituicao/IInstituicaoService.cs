using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public interface IInstituicaoService : IUsuarioService
    {
        Task<Instituicao> RecuperarInstituicaoPeloUserIdAsync(Guid useId);

        Task<IList<Instituicao>> ObterInstituicoesAsync();

        Task<Instituicao> ObterInstituicaoAsync(Guid id);
    }
}