﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Domain
{
    public class UserData
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public Guid InstituicaoId { get; set; }
    }
}
