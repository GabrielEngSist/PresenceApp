using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Domain
{
    public class Chamada
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClasseId { get; set; }

        public bool Ativa { get; set; }
    }
}
