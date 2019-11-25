using System;
using System.Threading.Tasks;
using Presence.API.Contracts.V1.Requests;
using Presence.API.Domain;

namespace Presence.API.Services
{
    internal class InstituicaoService : IInstituicaoService
    {
        public Task CriarUsuarioAsync(Guid UserId, UserRegistrationRequest usuario)
        {
            throw new NotImplementedException();
        }
    }
}