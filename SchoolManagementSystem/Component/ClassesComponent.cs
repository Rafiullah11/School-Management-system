using SchoolManagementSystem.Data;
using SchoolManagementSystem.IComponent;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Service;

namespace SchoolManagementSystem.Component
{
    public class ClassesComponent : IClassesComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public ClassesComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }

        public List<ClassesModel> Classes()
        {
            var list = _schoolContext.Class.ToList();
            var nl = new List<ClassesModel>();

            foreach (var item in list)
            {
                nl.Add(new ClassesModel()
                {
                    ClassId = item.Id,
                    Name = item.Name,

                });
            }
            return nl;

        }

        public bool DeleteClasses(int id)
        {
            var del = _schoolContext.Class.FirstOrDefault(X => X.Id == id);
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

        public ClassesModel GetClasses(int id)
        {
            var data = _schoolContext.Class.FirstOrDefault(X => X.Id == id);
            var get = new ClassesModel
            {
                ClassId = data.Id,
                Name = data.Name
            };


            return get;
           
        }

        public ClassesModel Save(ClassesModel cm)
        {
            var user = _services.GetUserId();

            //code for update
            if (cm.ClassId > 0)
            {

                var update = _schoolContext.Class.FirstOrDefault(X => X.Id == cm.ClassId);
                update.Id = cm.ClassId;
                update.Name = cm.Name;
                update.UpdatedOn = DateTime.Now;
                update.UpdatedBy = user; //Convert.ToInt32(user);

                _schoolContext.Update(update);
            }
            else
            {
                var create = new Classes();
                create.Id = cm.ClassId;
                create.Name = cm.Name;
                create.CreatedBy = user; //Convert.ToInt32(user);
                create.CreatedOn = DateTime.Now;

                _schoolContext.Class.Add(create);
            }
            _schoolContext.SaveChanges();
            return cm;
        }
    }
}
