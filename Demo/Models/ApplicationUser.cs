﻿using Microsoft.AspNetCore.Identity;

namespace Demo.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
