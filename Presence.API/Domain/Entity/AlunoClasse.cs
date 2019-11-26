using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Presence.API.Domain
{
    public class AlunoClasse
    {
        public Guid AlunoId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ClasseId))]
        public Aluno Aluno { get; set; }

        public Guid ClasseId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ClasseId))]
        public Classe Classe { get; set; }

    }
}
