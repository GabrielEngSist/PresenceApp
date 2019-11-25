using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Presence.API.Domain
{
    public class Professor
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }
        
        public Guid InstituicaoId { get; set; }

        public string Nome { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser Usuario { get; set; }

        [ForeignKey(nameof(InstituicaoId))]
        public Instituicao Instituicao { get; set; }
    }
}