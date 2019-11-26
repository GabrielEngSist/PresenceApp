using Presence.API.Contracts.V1.Requests;
using Presence.API.Data;
using Presence.API.Domain;
using Presence.API.Domain.Enum;
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

        public async Task<TipoUsuario> CriarUsuarioAsync(Guid userId, UserRegistrationRequest usuario)
        {
            var instituicao = await _dataContext.Instituicoes.FindAsync(usuario.InstituicaoId);

            if (instituicao == null)
            {
                throw new InvalidOperationException("A instituição não existe.");
            }

            var aluno = new Aluno
            {
                Nome = usuario.Nome,
                InstituicaoId = usuario.InstituicaoId,
                UserId = userId.ToString()
            };

            await _dataContext.Alunos.AddAsync(aluno);

            await _dataContext.SaveChangesAsync();
            return TipoUsuario.Aluno;
        }
    }
}