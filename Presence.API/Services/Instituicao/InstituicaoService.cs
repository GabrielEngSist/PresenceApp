using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Presence.API.Contracts.V1.Requests;
using Presence.API.Data;
using Presence.API.Domain;
using Presence.API.Domain.Enum;
using Presence.API.Utils.Exceptions;

namespace Presence.API.Services
{
    internal class InstituicaoService : IInstituicaoService
    {
        private readonly DataContext _dataContext;

        public InstituicaoService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<TipoUsuario> CriarUsuarioAsync(Guid UserId, UserRegistrationRequest usuario)
        {
            var jaExiste = await this._dataContext.Instituicoes.Where(i => i.Descricao == usuario.Nome).AnyAsync();

            if (jaExiste)
            {
                throw new RequestException(HttpStatusCode.BadRequest, "Instituição já cadastrada.");
            }

            var instituicao = new Instituicao
            {
                Descricao = usuario.Nome,
                UserId = UserId.ToString(),
            };

            await _dataContext.AddAsync(instituicao);

            return TipoUsuario.Instituicao;
        }

        public async Task<Instituicao> ObterInstituicaoAsync(Guid id)
        {
            return await _dataContext.Instituicoes.FindAsync(id);
        }

        public async Task<IList<Instituicao>> ObterInstituicoesAsync()
        {
            return await _dataContext.Instituicoes.ToListAsync();
        }

        public async Task<Instituicao> RecuperarInstituicaoPeloUserIdAsync(Guid userId)
        {
            return await _dataContext.Instituicoes.FirstOrDefaultAsync(i => i.UserId == userId.ToString());
        }
    }
}