using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class SectionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
