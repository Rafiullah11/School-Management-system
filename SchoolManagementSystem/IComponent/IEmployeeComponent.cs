using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
    public interface IEmployeeComponent
    {
        List<EmployeeViewModel> Employee();
        EmployeeViewModel Save(EmployeeViewModel evm);
        EmployeeViewModel GetEmployee(int id);
        bool Delete(int id);
    }
}
