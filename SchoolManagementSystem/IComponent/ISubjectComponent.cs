using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
    public interface ISubjectComponent
    {
        List<SubjectModel> Subjects();
        SubjectModel Save(SubjectModel sm);
        SubjectModel GetSubject(int id);
        bool Delete(int id);
    }
}
