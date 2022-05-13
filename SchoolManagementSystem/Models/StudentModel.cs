using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagementSystem.Model
{
  public  class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}
