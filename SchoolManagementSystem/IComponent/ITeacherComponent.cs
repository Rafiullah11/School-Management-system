using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
    public interface ITeacherComponent
    {
        List<TeacherViewModel> Teacher();
        List<TeacherViewModel> GetTeacherBySubjectId(int id);
        TeacherViewModel Save(TeacherViewModel tvm);
        TeacherViewModel GetTeacher(int id);
        bool Delete(int id);
    }
}
