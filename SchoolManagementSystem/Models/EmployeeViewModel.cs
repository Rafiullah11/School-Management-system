using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public int EmployeeId { get; set; }
    }
}
