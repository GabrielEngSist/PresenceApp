using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Domain
{
    public class Aluno
    {
        [Key]
        public Guid Id { get; set; }

        public string Matricula { get; set; }

        public string UserId { get; set; }

        public Guid InstituicaoId { get; set; }

        public string Nome { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser Usuario { get; set; }

        [ForeignKey(nameof(InstituicaoId))]
        public Instituicao Instituicao { get; set; }

        public IList<AlunoClasse> AlunoClasse { get; set; }

    }
}
