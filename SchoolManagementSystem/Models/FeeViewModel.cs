using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class FeeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }
        [Display(Name ="Student")]
        public int StudentId { get; set; }
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }
        public int MonthId { get; set; }
        public string Month { get; set; }

        public int Fees { get; set; }
    }
}
