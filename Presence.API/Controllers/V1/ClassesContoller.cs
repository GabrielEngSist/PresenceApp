using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presence.API.Contracts.V1;
using Presence.API.Contracts.V1.Requests.Classe;
using Presence.API.Domain;
using Presence.API.Extensions;
using Presence.API.Services;
using Presence.API.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presence.API.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClassesContoller : BaseController
    {
        private readonly IClasseService _classeService;
        private readonly IProfessorService _professorService;

        public ClassesContoller(
            IClasseService classeService,
            IProfessorService professorService,
            IInstituicaoService instituicaoService)
        {
            this._classeService = classeService;
            this._professorService = professorService;
        }

        [HttpPost(ApiRoutes.Classes.Criar)]
        public async Task<IActionResult> CriarClasse([FromBody] ClasseRegistrationRequest classeRequest)
        {
            try
            {
                var userId = HttpContext.ObterIdUsuario();
                var professor = await this._professorService.RecuperarProfessorPeloUserId(userId);

                var classe = new Classe
                {
                    Descricao = classeRequest.Descricao,
                    InstituicaoId = professor.InstituicaoId,
                    ProfessorId = professor.Id,
                };

                var retorno = await _classeService.CriarClasseAsync(classe);

                return Created("", retorno);

            }
            catch (RequestException ex)
            {
                return await RetornoHttp(ex.GetStatus(), ex.Message);
            }
            catch (Exception ex)
            {
                return await RetornoHttp(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Classes.Obter)]
        public async Task<IActionResult> ObterClasse([FromRoute] Guid id)
        {
            try
            {
                var classe = await this._classeService.ObterClasseAsync(id);
                return Ok(classe);
            }
            catch (RequestException ex)
            {
                return await RetornoHttp(ex.GetStatus(), ex.Message);
            }
            catch (Exception ex)
            {
                return await RetornoHttp(HttpStatusCode.InternalServerError, ex.Message);
            }            
        }

        [HttpGet(ApiRoutes.Classes.Pesquisar)]
        public async Task<IActionResult> PesquisarClasses([FromBody] PesquisarClassesRequest pesquisarClasses)
        {
            try
            {
                var classes = _classeService.ObterClassesAsync(pesquisarClasses.ProfessorId, pesquisarClasses.AlunoId, pesquisarClasses.IntituicaoId, pesquisarClasses.ClasseId);
                return Ok(classes);
            }
            catch (RequestException ex)
            {
                return await RetornoHttp(ex.GetStatus(), ex.Message);
            }
            catch (Exception ex )
            {
                return await RetornoHttp(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Classes.AdicionarAluno)]
        public async Task<IActionResult> AdicionarAluno([FromRoute] Guid alunoId, [FromRoute] Guid classeId)
        {
            try
            {
                var alunoClasse = new AlunoClasse
                {
                    AlunoId = alunoId,
                    ClasseId = classeId,
                };

                var resposta = await _classeService.CriarAlunoClasseAsync(alunoClasse);

                return Ok(resposta);
            }
            catch (RequestException ex)
            {
                return await RetornoHttp(ex.GetStatus(), ex.Message);
            }
            catch (Exception ex)
            {
                return await RetornoHttp(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
