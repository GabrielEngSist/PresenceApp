﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1
{

    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Presencas
        {   
            public const string ObterTodas = Base + "/presencas";
            public const string Obter = Base + "/presencas/{id}";
            public const string Deletar = Base + "/presencas/{id}";
            public const string Atualizar = Base + "/presencas/{id}";
            public const string Criar = Base + "/presencas";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";
        }

        public static class Classes
        {
            public const string Criar = Base + "/classes";
            public const string Obter = Base + "/classes/{id}";
            public const string Pesquisar = Base + "/classes";
            public const string AdicionarAluno = Base + "/classes/{classeId}/{alunoId}";
        }

        public static class Chamadas
        {
            public const string Criar = Base + "/chamadas/classe/{classeId}";
            public const string Alterar = Base + "/chamadas/{id}";
            public const string Obter = Base + "/chamadas/{id}";
            public const string ObterTodas = Base + "/chamadas/classe/{classeId}"; 
        }
    }
}
