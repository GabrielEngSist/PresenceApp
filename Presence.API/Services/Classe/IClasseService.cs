using Presence.API.Contracts.V1.Requests.Classe;
using Presence.API.Contracts.V1.Responses.Presenca;
using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public interface IClasseService
    {
        Task<AlunoClasse> CriarAlunoClasseAsync(AlunoClasse alunoClasse);

        Task<Classe> CriarClasseAsync(Classe classe);

        Task<IList<ClassePesquisaResponse>> ObterClassesAsync(
            Guid professorId,
            Guid alunoId,
            Guid instituicaoId,
            Guid classeId);
    }
}