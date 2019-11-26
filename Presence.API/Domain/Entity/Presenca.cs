using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presence.API.Domain
{

    public class Presenca
    {
        [Key]
        public Guid Id { get; set; }

        public string Observacao { get; set; }

        public int Nota { get; set;}

        public Guid ChamadaId { get; set; }

        public string UserId { get; set; }

        [Timestamp]
        public DateTime DataCadastro { get; set; }

        public Guid ClasseId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        [ForeignKey(nameof(ClasseId))]
        public Classe Classe { get; set; }

        [ForeignKey(nameof(ChamadaId))]
        public Chamada Chamada { get; set; }
    }
}
