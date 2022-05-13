using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
    public interface IFeeComponent
    {
        List<FeeViewModel> Index();
        FeeViewModel Save(FeeViewModel fvm);
        FeeViewModel GetFee(int id);
        bool Delete(int id);
    }
}
