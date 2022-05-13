using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
    public interface IClassesComponent
    {
        List<ClassesModel> Classes();
        ClassesModel Save(ClassesModel cm);

        ClassesModel GetClasses(int id);

        bool DeleteClasses(int id);
    }
}
