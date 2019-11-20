using Presence.API.Contracts.V1.Requests;
using Presence.API.Data;
using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    internal class AlunoService : IAlunoService
    {
        protected readonly DataContext _dataContext;

        public AlunoService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<Presenca> AvaliarPresencaAsync(Guid PresencaId, Guid AlunoId, int nota, string observacao)
        {
            var presenca = await this._dataContext.Presencas.FindAsync(PresencaId);
            var aluno = await this._dataContext.Alunos.FindAsync(AlunoId);
            if (presenca.UserId != aluno.UserId)
            {
                throw new InvalidOperationException("Esta presença não é sua.");
            }

            presenca.Nota = nota;
            presenca.Observacao = observacao;

            await _dataContext.SaveChangesAsync();

            return presenca;
        }

        public Task CriarUsuarioAsync(Guid UserId, UserRegistrationRequest usuario)
        {
            throw new NotImplementedException("Método não implementado.");
        }

        public Task<IList<Presenca>> ObterPresencasPorAlunoAsync(Guid AlunoId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Presenca>> ObterPresencasPorClasseAsync(Guid ClasseId, Guid AlunoId)
        {
            throw new NotImplementedException();
        }
    }
}