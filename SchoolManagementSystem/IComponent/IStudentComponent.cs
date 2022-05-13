using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementSystem.IComponent
{
   public interface IStudentComponent
    {
        List<StudentModel> Students();
        StudentModel Save(StudentModel vm);
        StudentModel GetStudent(int id);
        List<StudentModel> GetStudentBySectionId(int classId,int sectionId);
        bool Delete(int id);
    }
}
