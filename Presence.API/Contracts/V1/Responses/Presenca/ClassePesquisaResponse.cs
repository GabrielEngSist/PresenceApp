using Presence.API.Contracts.V1.Responses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Responses.Presenca
{
    public class ClassePesquisaResponse
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public IdNomeDto Instituicao { get; set; }
        
        public IdNomeDto Professor { get; set; }

        public List<IdNomeDto> Alunos { get; set; }
    }
}
