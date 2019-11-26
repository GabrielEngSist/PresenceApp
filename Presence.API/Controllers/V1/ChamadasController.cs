using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presence.API.Contracts.V1;
using Presence.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presence.API.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ChamadasController : BaseController
    {
        private readonly IChamadaService _chamadaService;

        public ChamadasController(
            IChamadaService chamadaService)
        {
            this._chamadaService = chamadaService;
        }

        [HttpPost(ApiRoutes.Chamadas.Criar)]
        public async Task<IActionResult> CriarChamada([FromRoute] Guid classeId)
        {
            try
            {
                var chamadaId = await _chamadaService.CriarChamadaAsync(classeId);
                return Created(ApiRoutes.Chamadas.Obter.Replace("{id}", chamadaId.ToString()), chamadaId);
            }
            catch (Exception ex)
            {
                return await RetornoHttp(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}