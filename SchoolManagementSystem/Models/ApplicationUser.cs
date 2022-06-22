﻿using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string City { get; set; }
    }
}
