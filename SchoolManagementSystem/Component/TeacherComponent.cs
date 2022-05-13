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
    public class TeacherComponent : ITeacherComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public TeacherComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.Teachers.FirstOrDefault(X => X.Id == id);
            if (del!=null)
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

        public TeacherViewModel GetTeacher(int id)
        {
            var data = _schoolContext.Teachers.FirstOrDefault(X => X.Id == id);
            var get = new TeacherViewModel();

            get.Id = data.Id;
            get.Name = data.Name;
            get.Email = data.Email;
            get.SubjectId = data.SubjectId;
            get.Designation = data.Designation;
            get.Qualification = data.Qualification;
            get.Address = data.Address;

            return get;
        }

        public List<TeacherViewModel> GetTeacherBySubjectId(int id)
        {
            var list = _schoolContext.Teachers.Where(x => x.SubjectId == id).ToList();
            var nl = new List<TeacherViewModel>();
            foreach (var item in list)
            {
                nl.Add(new TeacherViewModel()
                {
                    Id = item.Id,
                    Name=item.Name
                });   
            }
            return nl;
        }

        public TeacherViewModel Save(TeacherViewModel tvm)
        {
            var user = _services.GetUserId();
            if (tvm.Id>0)
            {
                var update = _schoolContext.Teachers.FirstOrDefault(X => X.Id == tvm.Id);

                update.Id = tvm.Id;
                update.Name = tvm.Name;
                update.Email = tvm.Email;
                update.SubjectId = tvm.SubjectId;
                update.Designation = tvm.Designation;
                update.Qualification = tvm.Qualification;
                update.Address = tvm.Address;
                update.UpdatedOn = DateTime.Now;
                update.UpdatedBy = user;

                _schoolContext.Teachers.Update(update);
            }
            else
            {
                var create = new Teacher();
                create.Id = tvm.Id;
                create.Name = tvm.Name;
                create.Email = tvm.Email;
                create.SubjectId = tvm.SubjectId;
                create.Designation = tvm.Designation;
                create.Qualification = tvm.Qualification;
                create.Address = tvm.Address;
                create.CreatedOn = DateTime.Now;
                create.CreatedBy = user;

                _schoolContext.Teachers.Add(create);
            }
            _schoolContext.SaveChanges();
            return tvm;
        }

        public List<TeacherViewModel> Teacher()
        {
            var list = _schoolContext.Teachers.ToList();
            var nl = new List<TeacherViewModel>();

            foreach (var item in list)
            {
                var Sub = _schoolContext.Subjects.FirstOrDefault(x => x.Id == item.SubjectId);
                nl.Add(new TeacherViewModel() { 
                    Id=item.Id,
                    Name=item.Name,
                    Email=item.Email,
                    SubjectId=item.SubjectId,
                    SubjectName=Sub.Name,
                    Designation=item.Designation,
                    Qualification=item.Qualification,
                    Address=item.Address
                });
            }
            return nl;
        }
    }
}
