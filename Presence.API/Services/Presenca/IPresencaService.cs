using Presence.API.Contracts.V1.Responses.Presenca;
using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presence.API.Services
{

    public interface IPresencaService
    {        
        Task<IList<Presenca>> ObterPresencasAsync();

        Task<bool> CriarPresencaAsync(Presenca presenca);

        Task<Presenca> ObterPresencaAsync(Guid id);
    
        Task<bool> AtualizaPresencaAsync(Presenca presenca);

        Task<bool> DeletarPresencaAsync(Guid id);

        Task<bool> PresencaPertenceAoUsuarioAsync(Guid id, Guid userId);

        Task<IList<PresencaPesquisaResponse>> PesquisarPresencasAsync(Guid classeId, Guid alunoId, Guid professorId, Guid InstituicaoId);

        Task<Presenca> AvaliarPresencaAsync(Guid presencaId, Guid userId, int nota, string observacao);
    }
}
