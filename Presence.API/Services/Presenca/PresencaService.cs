using Microsoft.EntityFrameworkCore;
using Presence.API.Contracts.V1.Responses.DTO;
using Presence.API.Contracts.V1.Responses.Presenca;
using Presence.API.Data;
using Presence.API.Domain;
using Presence.API.Utils;
using Presence.API.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Services
{

    public class PresencaService : IPresencaService
    {
        private readonly DataContext _dataContext;
        private readonly IChamadaService _chamadaService;
        public PresencaService(DataContext dataContext, IChamadaService chamadaService)
        {
            this._dataContext = dataContext;
            this._chamadaService = chamadaService;
        }

        public async Task<bool> AtualizaPresencaAsync(Presenca presenca)
        {
            _dataContext.Presencas.Update(presenca);
            var linhas = await _dataContext.SaveChangesAsync();
            return linhas > 0;
        }

        public async Task<bool> DeletarPresencaAsync(Guid id)
        {
            var presenca = await ObterPresencaAsync(id);

            if(presenca == null)
            {
                return false;
            }

            _dataContext.Presencas.Remove(presenca);
            var linhas = await _dataContext.SaveChangesAsync();

            return linhas > 0;
        }

        public async Task<bool> CriarPresencaAsync(Presenca presenca)
        {
            var chamada = await _chamadaService.ObterChamadaAsync(presenca.ChamadaId);

            if (chamada == null)
            {
                throw new RequestException(System.Net.HttpStatusCode.NotFound, "Chamada não encontrada.");
            }
            
            if (!chamada.Ativa)
            {
                throw new RequestException(System.Net.HttpStatusCode.BadRequest, "A chamada não está ativa!");
            }

            await _dataContext.Presencas.AddAsync(presenca);
            var linhas = await _dataContext.SaveChangesAsync();
            return linhas > 0;
        }

        public async Task<Presenca> ObterPresencaAsync(Guid id)
        {
            return await _dataContext.Presencas.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IList<Presenca>> ObterPresencasAsync()
        {
            return await _dataContext.Presencas.ToListAsync();
        }

        public async Task<bool> PresencaPertenceAoUsuarioAsync(Guid id, Guid userId)
        {
            var presenca = await _dataContext.Presencas.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

            return presenca != null && presenca.UserId == userId.ToString();
        }

        public async Task<IList<PresencaPesquisaResponse>> PesquisarPresencasAsync(
            Guid classeId,
            Guid alunoId,
            Guid professorId,
            Guid instituicaoId)
        {
            var query = _dataContext.Presencas
                .Join(_dataContext.Alunos, p => p.UserId, a => a.UserId, (p, a) => new { p, a })
                .Join(_dataContext.Classes, pa => pa.p.ClasseId, c => c.Id, (pa, c) => new { pa, c })
                .Join(_dataContext.Professores, pac => pac.c.ProfessorId, p => p.Id, (pac, p) => new { pac, p })
                .Join(_dataContext.Instituicoes, pacp => pacp.pac.c.InstituicaoId, i => i.Id, (pacp, i) => new { pacp, i });
            
            if (alunoId != Guid.Empty)
            {
                query.Where(pacpi => pacpi.pacp.pac.pa.a.Id == alunoId);
            }

            if (professorId != Guid.Empty)
            {
                query.Where(pacpi => pacpi.pacp.p.Id == professorId);
            }

            if (classeId != Guid.Empty)
            {
                query.Where(pacpi => pacpi.pacp.pac.c.Id == classeId);
            }

            if (instituicaoId != Guid.Empty)
            {
                query.Where(pacpi => pacpi.i.Id == instituicaoId);
            }

            return await query.Select(pacpi => new PresencaPesquisaResponse 
            { 
                Id = pacpi.pacp.pac.pa.p.Id,
                DataCadastro = pacpi.pacp.pac.pa.p.DataCadastro,
                Instituicao = pacpi.i.ConverterParaIdNomeDto("Descricao"),
                Aluno = pacpi.pacp.pac.pa.a.ConverterParaIdNomeDto("Nome"),
                Classe = pacpi.pacp.pac.c.ConverterParaIdNomeDto("Descricao")
            }).ToListAsync();
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
    }
}
