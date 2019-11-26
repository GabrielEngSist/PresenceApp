using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Requests.Classe
{
    public class ClasseRegistrationRequest
    {
        public string Descricao { get; set; }

        public Guid InstituicaoId { get; set; }
    }
}
