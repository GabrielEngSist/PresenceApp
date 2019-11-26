using Presence.API.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Responses
{

    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public string Nome { get; set; }
    }
}
