﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Contracts.V1.Requests
{

    public class UserLoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
