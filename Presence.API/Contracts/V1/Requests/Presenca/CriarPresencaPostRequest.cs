using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Requests
{

    public class CriarPresencaPostRequest
    {
        public Guid ChamadaId { get; set; }
        public string Observacao { get; set; }
    }
}
