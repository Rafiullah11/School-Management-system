using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}
