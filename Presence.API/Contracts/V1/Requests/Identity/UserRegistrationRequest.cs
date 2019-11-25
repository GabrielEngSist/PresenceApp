using Presence.API.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Requests
{

    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string UserName { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Guid InstituicaoId { get; set; }
    }
}
