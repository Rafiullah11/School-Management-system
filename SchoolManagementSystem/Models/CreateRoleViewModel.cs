using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
