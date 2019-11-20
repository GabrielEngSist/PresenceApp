using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presence.API.Domain
{
    public class Classe
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProfessorId { get; set; }

        public Guid InstituicaoId { get; set; }

        public String Descricao { get; set; }

        [ForeignKey(nameof(ProfessorId))]
        public Professor professor { get; set; }

        [ForeignKey(nameof(InstituicaoId))]
        public Instituicao Instituicao { get; set; }

        public IList<AlunoClasse> AlunoClasse { get; set; }
    }
}