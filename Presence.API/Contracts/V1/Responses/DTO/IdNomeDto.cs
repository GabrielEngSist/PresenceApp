using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Responses.DTO
{
    public class IdNomeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
