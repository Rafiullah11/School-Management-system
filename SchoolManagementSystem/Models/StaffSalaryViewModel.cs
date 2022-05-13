using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class StaffSalaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MonthName { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public int StaffId { get; set; }
        public int EmployeeId { get; set; }
        public int TeacherId { get; set; }
        public decimal Salary { get; set; }
        public int Month { get; set; }
        public string Year { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

}
