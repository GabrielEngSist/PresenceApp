using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public interface IAlunoService : IUsuarioService
    {
        Task<IList<Presenca>> ObterPresencasPorClasseAsync(Guid ClasseId, Guid AlunoId);

        Task<IList<Presenca>> ObterPresencasPorAlunoAsync(Guid AlunoId);

        Task<Presenca> AvaliarPresencaAsync(Guid PresencaId, Guid AlunoId, int nota, string observacao);
    }
}