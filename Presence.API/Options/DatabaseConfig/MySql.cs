using Presence.API.Extensions;
using Presence.API.Options.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Presence.API.Options
{

    public class MySql : IConnectionStrings
    {
        private string _connectionString;

public MySql(string connectionString)
        {
            this._connectionString = connectionString;
        }

public string ObterConnectionString()
        {
            return this._connectionString;
        }

public DatabaseTypes ObterTipoBancoDados()
        {
            return DatabaseTypes.MySql;
        }
    }
}
