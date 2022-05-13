using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
    public interface IStaffSalaryComponent
    {
        List<StaffSalaryViewModel> StaffSalary();
        StaffSalaryViewModel Save(StaffSalaryViewModel svm);
        StaffSalaryViewModel GetStaffSalary(int id);
       // List<StaffSalaryViewModel> GetSalaryByTypeId( int id);
        bool Delete(int id);

    }
}
