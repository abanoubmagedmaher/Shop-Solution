﻿using Microsoft.AspNetCore.Identity;

namespace Shop.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string? Address { get; set; }
    }
}
