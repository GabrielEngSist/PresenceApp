using Microsoft.EntityFrameworkCore;
using Presence.API.Data;
using Presence.API.Domain;
using Presence.API.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Services
{
    public class ChamadaService : IChamadaService
    {
        private readonly DataContext _dataContext;
        public ChamadaService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<Guid> CriarChamadaAsync(Guid classeId)
        {
            var existeClasse = await _dataContext.Classes.AnyAsync(c => c.Id == classeId);

            if (!existeClasse)
            {
                throw new RequestException(System.Net.HttpStatusCode.BadRequest, "A classe solicitada não existe.");
            }

            var chamadaAtiva = await _dataContext.Chamadas.AnyAsync(c => c.ClasseId == classeId && c.Ativa);

            if (chamadaAtiva)
            {
                throw new RequestException(System.Net.HttpStatusCode.BadRequest, "Já existe uma chamada ativa para esta turma!");
            }

            var chamada = new Chamada
            {
                ClasseId = classeId,
                Ativa = true,
            };

            await _dataContext.Chamadas.AddAsync(chamada);
            await _dataContext.SaveChangesAsync();
            return chamada.Id;
        }

        public async Task<bool> FinalizarChamadaAsync(Guid id)
        {
            var chamada = await _dataContext.Chamadas.FindAsync(id);
            chamada.Ativa = false;
            await _dataContext.SaveChangesAsync();
            return !chamada.Ativa;
        }

        public async Task<Chamada> ObterChamadaAsync(Guid id)
        {
            return await _dataContext.Chamadas.FindAsync(id);
        }

        public async Task<IList<Chamada>> ObterChamadasPorClasseAsync(Guid classeId)
        {
            return await _dataContext.Chamadas.Where(c => c.ClasseId == classeId).ToListAsync();
        }

        public async Task<bool> ReabrirChamadaAsync(Guid id)
        {
            var chamada = await _dataContext.Chamadas.FindAsync(id);
            chamada.Ativa = true;
            await _dataContext.SaveChangesAsync();
            return chamada.Ativa;
        }
    }
}
