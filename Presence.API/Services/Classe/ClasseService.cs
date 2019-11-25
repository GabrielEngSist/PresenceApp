using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Presence.API.Contracts.V1.Requests.Classe;
using Presence.API.Contracts.V1.Responses.DTO;
using Presence.API.Contracts.V1.Responses.Presenca;
using Presence.API.Data;
using Presence.API.Domain;
using Presence.API.Utils;

namespace Presence.API.Services
{
    public class ClasseService : IClasseService
    {
        private readonly DataContext _dataContext;

        public ClasseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<AlunoClasse> CriarAlunoClasseAsync(AlunoClasse alunoClasse)
        {
            await _dataContext.AlunosClasses.AddAsync(alunoClasse);
            return alunoClasse;
        }

        public async Task<Classe> CriarClasseAsync(Classe classe)
        {
            await _dataContext.Classes.AddAsync(classe);
            return classe;
        }

        public async Task<IList<ClassePesquisaResponse>> ObterClassesAsync(
            Guid professorId, 
            Guid alunoId, 
            Guid instituicaoId, 
            Guid classeId)
        {
            var query = _dataContext.Classes
                .Join(_dataContext.Professores,
                c => c.ProfessorId,
                p => p.Id,
                (c, p) => new { c, p })
                .Join(_dataContext.Instituicoes,
                cp => cp.c.InstituicaoId,
                i => i.Id,
                (cp, i) => new { cp, i });
            
            if (alunoId != Guid.Empty)
            {
                var id = _dataContext.Classes
                .Join(
                    _dataContext.AlunosClasses, 
                    c => c.Id, 
                    ac => ac.ClasseId, 
                    (c, ac) => new { c, ac })
                .Join(
                    _dataContext.Alunos, 
                    cac => cac.ac.AlunoId, 
                    a => a.Id, 
                    (cac, a) => new { cac, a })
                .Select(caca => caca.cac.c.Id)
                .ToList();

                query.Where(cpi => id.Contains(cpi.cp.c.Id));
            }

            if (professorId != Guid.Empty)
            {
                query.Where(cpi => cpi.cp.p.Id == professorId);
            }

            if (classeId != Guid.Empty)
            {
                query.Where(cpi => cpi.cp.c.Id == classeId);
            }

            return await query.Select(cpi => new ClassePesquisaResponse
                {
                    Id = cpi.cp.c.Id,
                    Alunos = _dataContext.AlunosClasses.Join(
                        _dataContext.Alunos,
                        ac => ac.AlunoId,
                        a => a.Id,
                        (ac, a) => new { ac, a })
                    .Select(result => result.a.ConverterParaIdNomeDto("Nome"))
                    .ToList(),
                    Instituicao = cpi.i.ConverterParaIdNomeDto("Descricao"),
                    Professor = cpi.cp.p.ConverterParaIdNomeDto("Nome")
                }).ToListAsync();
        }
    }
}