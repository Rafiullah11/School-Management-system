using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class StaffSalary
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public decimal Salary { get; set; }
        public int Month { get; set; }
        public string Year { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
