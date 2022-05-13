using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.IComponent
{
     public interface ISectionComponent
    {
        List<SectionModel> Index();
        SectionModel Save(SectionModel sm);
        SectionModel GetSection(int id);
        List<SectionModel> GetSectionByClassId(int id);
        bool Delete(int id);

    }
}
