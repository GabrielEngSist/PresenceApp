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

        
    }
}
