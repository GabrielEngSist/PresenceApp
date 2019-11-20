using Presence.API.Contracts.V1.Requests;
using Presence.API.Domain.Enum;
using System;

namespace Presence.API.Services
{
    public class UsuarioStrategy : IUsuarioStrategy
    {
        private TipoUsuario _tipoUsuario;
        private readonly IProfessorService _professorService;
        private readonly IInstituicaoService _instituicaoService;
        private readonly IAlunoService _alunoService;

        public UsuarioStrategy(
            IAlunoService alunoService,
            IInstituicaoService instituicaoService,
            IProfessorService professorService)
        {
            this._professorService = professorService;
            this._alunoService = alunoService;
            this._instituicaoService = instituicaoService;
        }

        public IUsuarioService RecuperarEstrategia(UserRegistrationRequest usuario)
        {
            switch (usuario.TipoUsuario)
            {
                case TipoUsuario.Professor:
                    return this._professorService;
                case TipoUsuario.Aluno:
                    return this._alunoService;
                case TipoUsuario.Instituicao:
                    return this._instituicaoService;
                default:
                    throw new InvalidOperationException("Não foi possível identificar o Tipo do usuário.");
            }
        }
    }
}