using Presence.API.Contracts.V1.Requests;
using Presence.API.Data;
using Presence.API.Domain;
using Presence.API.Utils.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public class ProfessorService : IUsuarioService, IProfessorService
    {

        private readonly DataContext _dataContext;

        public ProfessorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CriarUsuarioAsync(Guid UserId, UserRegistrationRequest usuario)
        {
            var professor = new Professor 
            { 
                UserId = UserId.ToString(),
                Nome = usuario.UserName,
            };
            
            await this._dataContext.Professores.AddAsync(professor);
        }

        public async Task<Professor> RecuperarProfessorPeloUserId(Guid userId)
        {
            var professor = await Task.Run(() => { return _dataContext.Professores.First(p => p.UserId == userId.ToString()); });

            if (professor == null)
            {
                throw new RequestException(HttpStatusCode.NotFound, "Professor não encontrado!");
            }

            return professor;
        }
    }
}
