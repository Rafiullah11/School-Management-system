using SchoolManagementSystem.Data;
using SchoolManagementSystem.IComponent;
using SchoolManagementSystem.Model;
using SchoolManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagementSystem.Component
{
    public class StudentComponent : IStudentComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public StudentComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.Students.FirstOrDefault(X => X.Id == id);
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

        public StudentModel GetStudent(int id)
        {
            var data = _schoolContext.Students.FirstOrDefault(X => X.Id == id);
            var get = new StudentModel();
            get.Id = data.Id;
            get.Name = data.Name;
            get.Email = data.Email;
            get.ClassId = data.ClassId;
            get.SectionId = data.SectionId;
            get.Address = data.Address;
            
            return get;
        }

        public List<StudentModel> GetStudentBySectionId(int classId, int sectionId)
        {
            var list = _schoolContext.Students.Where(x => x.ClassId== classId && x.SectionId == sectionId).ToList();
            var nl = new List<StudentModel>();
            foreach (var item in list)
            {
                nl.Add(new StudentModel()
                {
                    Id=item.Id,
                    Name=item.Name,
                });
            }
            return nl;
        }

        public StudentModel Save(StudentModel vm)
        {
            var user = _services.GetUserId();

            if (vm.Id>0)
            {
                var update = _schoolContext.Students.FirstOrDefault(X => X.Id == vm.Id);

                update.Id = vm.Id;
                update.Name = vm.Name;
                update.SectionId = vm.SectionId;
                update.ClassId = vm.ClassId;
                update.Email = vm.Email;
                update.UpdatedBy = user;
                update.UpdatedOn = DateTime.Now;
                update.Address = vm.Address;

                _schoolContext.Update(update);
            }
            else
            {
                var create = new Student();
                create.Id = vm.Id;
                create.Name = vm.Name;
                create.SectionId = vm.SectionId;
                create.Email = vm.Email;
                create.ClassId = vm.ClassId;
                create.CreatedBy = user;
                create.CreatedOn = DateTime.Now;
                create.Address = vm.Address;

                _schoolContext.Students.Add(create);
            }
            _schoolContext.SaveChanges();
            return vm;
        }

        public List<StudentModel> Students()
        {
            var list = _schoolContext.Students.ToList();
            var nl = new List<StudentModel>();
            foreach (var item in list)
            {
                var cls = _schoolContext.Class.FirstOrDefault(x => x.Id == item.ClassId);
                var sec = _schoolContext.Sections.FirstOrDefault(x => x.Id == item.SectionId);

                nl.Add(new StudentModel()
                {
                    Id=item.Id,
                    Name=item.Name,
                    Email=item.Email,
                    ClassId=item.ClassId,
                    ClassName=cls.Name,
                    SectionId=item.SectionId,
                    SectionName=sec.Name,
                    Address=item.Address
                });
            }
            return nl;
        }
    }
}
