using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public int TeacherId { get; set; }
    }
}
