using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]

        public string UserName { get; set; }  
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Remember Me")]
        public string RememberMe { get; set; }


    }
}
