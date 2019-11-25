using Presence.API.Contracts.V1.Responses.DTO;
using System;

namespace Presence.API.Contracts.V1.Responses.Presenca
{
    public class PresencaPesquisaResponse
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public IdNomeDto Instituicao { get; set; }
        public IdNomeDto Classe { get; set; }
        public IdNomeDto Aluno { get; set; }
    }
}
