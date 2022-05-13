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
    public class SubjectComponent : ISubjectComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public SubjectComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.Subjects.FirstOrDefault(X => X.Id == id);
            if (del!=null)
            {
                _schoolContext.Remove(del);
                _schoolContext.SaveChanges();
                return true;
            }
            return false;
        }

        public SubjectModel GetSubject(int id)
        {
            var data = _schoolContext.Subjects.FirstOrDefault(X => X.Id == id);
            var get = new SubjectModel();
            get.Id = data.Id;
            get.Name = data.Name;

            return get;
        }

        public SubjectModel Save(SubjectModel sm)
        {
            var user = _services.GetUserId();
            var update = _schoolContext.Subjects.FirstOrDefault(X => X.Id == sm.Id);
            if (sm.Id>0)
            {
                update.Id = sm.Id;
                update.Name = sm.Name;
                update.UpdatedBy = user;
                update.UpdatedOn = DateTime.Now;

                _schoolContext.Update(update);
            }
            else
            {
                var create = new Subject();
                create.Id = sm.Id;
                create.Name = sm.Name;
                create.CreatedBy = user;
                create.CreatedOn = DateTime.Now;

                _schoolContext.Add(create);
            }
            _schoolContext.SaveChanges();
            return sm;
        }

        public List<SubjectModel> Subjects()
        {
            var list = _schoolContext.Subjects.ToList();
            var nl = new List<SubjectModel>();
            foreach (var item in list)
            {
                nl.Add(new SubjectModel(){
                    Id=item.Id,
                    Name=item.Name,
                    
                });
            }
            return nl;
        }
    }
}
