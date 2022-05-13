using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Fee
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int StudentId { get; set; }
        public int MonthId { get; set; }
        public int Fees { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
