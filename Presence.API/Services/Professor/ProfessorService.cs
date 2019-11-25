using Presence.API.Contracts.V1.Requests;
using Presence.API.Data;
using Presence.API.Domain;
using System;
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
    }
}
