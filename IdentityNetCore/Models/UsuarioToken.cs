﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityNetCore.Models
{
    public class UsuarioToken:IdentityUserToken<int>
    {
        [Key]
        public int IdUsuarioToken { get; set; }
    }
}
