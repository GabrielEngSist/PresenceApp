using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presence.API.Domain;

namespace Presence.API.Services
{
    public interface IChamadaService
    {
        Task<Guid> CriarChamadaAsync(Guid classeId);

        Task<bool> FinalizarChamadaAsync(Guid id);

        Task<bool> ReabrirChamadaAsync(Guid id);

        Task<IList<Chamada>> ObterChamadasPorClasseAsync(Guid classeId);

        Task<Chamada> ObterChamadaAsync(Guid id);
    }
}
