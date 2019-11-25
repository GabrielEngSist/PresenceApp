using Presence.API.Domain;
using System;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public interface IProfessorService : IUsuarioService
    {
        Task<Professor> RecuperarProfessorPeloUserId(Guid userId);
    }
}