﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
     public class AppUser: IdentityUser
    {
        public string UserLogin { get; set; }
    }
}
