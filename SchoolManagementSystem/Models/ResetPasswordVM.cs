using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class ResetPasswordVM
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare("Password", ErrorMessage ="Password and confirm not match")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
