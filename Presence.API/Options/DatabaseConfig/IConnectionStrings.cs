using Presence.API.Options.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Options
{

    public interface IConnectionStrings
    {
        
        string ObterConnectionString();
        
        
        DatabaseTypes ObterTipoBancoDados();
    }
}
