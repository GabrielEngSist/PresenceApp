using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presence.API.Controllers.V1
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> RetornoHttp(HttpStatusCode statusCode, dynamic retorno)
        {
            return await Task.Run(()=> {
                switch (statusCode)
                {
                    case HttpStatusCode.Continue:
                        return Ok();
                    case HttpStatusCode.SwitchingProtocols:
                        return Ok();
                    case HttpStatusCode.Processing:
                        return Ok();
                    case HttpStatusCode.EarlyHints:
                        return Ok();
                    case HttpStatusCode.OK:
                        return Ok();
                    case HttpStatusCode.Created:
                        return Created(retorno.Uri, retorno.value);
                    case HttpStatusCode.Accepted:
                        return Accepted();
                    case HttpStatusCode.NonAuthoritativeInformation:
                        return Ok();
                    case HttpStatusCode.NoContent:
                        return Ok();
                    case HttpStatusCode.MovedPermanently:
                        return Ok();
                    case HttpStatusCode.Found:
                        return Ok();
                    case HttpStatusCode.SeeOther:
                        return Ok();
                    case HttpStatusCode.NotModified:
                        return Ok();
                    case HttpStatusCode.TemporaryRedirect:
                        return Ok();
                    case HttpStatusCode.BadRequest:
                        return Ok();
                    case HttpStatusCode.Unauthorized:
                        return Ok();
                    case HttpStatusCode.Forbidden:
                        return Ok();
                    case HttpStatusCode.NotFound:
                        return NotFound(retorno);
                    case HttpStatusCode.MethodNotAllowed:
                        return Ok();
                    case HttpStatusCode.NotAcceptable:
                        return Ok();
                    case HttpStatusCode.PreconditionFailed:
                        return Ok();
                    case HttpStatusCode.UnsupportedMediaType:
                        return Ok();
                    case HttpStatusCode.InternalServerError:
                        return Ok();
                    case HttpStatusCode.NotImplemented:
                        return Ok();
                    default: return Ok();
                }
            });
        }
    }
}
