using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Responses
{

    public class ObterPresencaResponse
    {
        public Guid Id { get; set; }

        public string Observacao { get; set; }

        public int Nota { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
