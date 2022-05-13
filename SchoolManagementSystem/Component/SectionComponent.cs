using SchoolManagementSystem.Data;
using SchoolManagementSystem.IComponent;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Component
{
    public class SectionComponent : ISectionComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public SectionComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.Sections.FirstOrDefault(X => X.Id == id);
            if (del !=null)
            {
                _schoolContext.Remove(del);
                _schoolContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public SectionModel GetSection( int id)
        {
            var data = _schoolContext.Sections.FirstOrDefault(X => X.Id == id);

            var get = new SectionModel
            {
                Id = data.Id,
                Name = data.Name,
                ClassId = data.ClassId,
            };
            return get;
        }

        public List<SectionModel> GetSectionByClassId(int id)
        {
            var list = _schoolContext.Sections.Where(x=>x.ClassId==id).ToList();
            var nl = new List<SectionModel>();

            foreach (var item in list)
            {
                nl.Add(new SectionModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return nl;
        }

        public List<SectionModel> Index()
        {
            var list = _schoolContext.Sections.ToList();
            var nl = new List<SectionModel>();

            foreach (var item in list)
            {
                var classs = _schoolContext.Class.FirstOrDefault(x => x.Id == item.ClassId);
                nl.Add(new SectionModel()
                {
                    Id = item.Id,
                    Name=item.Name,
                    ClassId=item.ClassId,
                    ClassName= classs.Name
                });
            }
            return nl;
        }

        public SectionModel Save(SectionModel sm)
        {
            var user = _services.GetUserId();

            if (sm.Id > 0)
            {
                var update = _schoolContext.Sections.FirstOrDefault(X => X.Id == sm.Id);
                update.Id = sm.Id;
                update.Name = sm.Name;
                update.ClassId = sm.ClassId;
                update.UpdatedBy = user;
                update.UpdatedOn = DateTime.Now;

                _schoolContext.Update(update);
            }
            else
            {
                var create = new Section();
                create.Id = sm.Id;
                create.Name = sm.Name;
                create.ClassId = sm.ClassId;
                create.CreatedOn = DateTime.Now;
                create.CreatedBy = user;
                _schoolContext.Sections.Add(create);
            }
            _schoolContext.SaveChanges();
            return sm;
        }
    }
}
