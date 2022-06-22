﻿using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class ForgotPasswordVM
    {
        [Required,EmailAddress]
        public string Email { get; set; }
    }
}
