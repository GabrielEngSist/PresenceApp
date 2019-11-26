using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Requests.Classe
{
    public class PesquisarClassesRequest
    {
        public Guid IntituicaoId { get; set; }

        public Guid AlunoId { get; set; }

        public Guid ProfessorId { get; set; }

        public Guid ClasseId { get; set; }
    }
}
