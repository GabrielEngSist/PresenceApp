﻿using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Services
{

    public interface IPresencaService
    {        
        Task<List<Presenca>> ObterPresencasAsync();

        Task<bool> CriarPresencaAsync(Presenca presenca);

        Task<Presenca> ObterPresencaAsync(Guid id);
    
        Task<bool> AtualizaPresencaAsync(Presenca presenca);

        Task<bool> DeletarPresencaAsync(Guid id);

        Task<bool> PresencaPertenceAoUsuarioAsync(Guid id, Guid userId);
    }
}
