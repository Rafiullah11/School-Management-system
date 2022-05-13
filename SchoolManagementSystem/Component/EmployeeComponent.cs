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
    public class EmployeeComponent : IEmployeeComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public EmployeeComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.Employees.FirstOrDefault(X => X.Id == id);
            if (del != null)
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

        public List<EmployeeViewModel> Employee()
        {
            var list = _schoolContext.Employees.ToList();
            var nl = new List<EmployeeViewModel>();
            foreach (var item in list)
            {
                nl.Add(new EmployeeViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Designation = item.Designation,
                    Mobile = item.Mobile,
                    Email = item.Email,
                    Address = item.Address
                });
            }
            return nl;
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            var data = _schoolContext.Employees.FirstOrDefault(X => X.Id == id);
            var get = new EmployeeViewModel();

            get.Id = data.Id;
            get.Name = data.Name;
            get.Designation = data.Designation;
            get.Email = data.Email;
            get.Mobile = data.Mobile;
            get.Address = data.Address;

            return get;
        }

        public EmployeeViewModel Save(EmployeeViewModel evm)
        {
            var user = _services.GetUserId();
            if (evm.Id > 0)
            {
                var update = _schoolContext.Employees.FirstOrDefault(X => X.Id == evm.Id);
                update.Id = evm.Id;
                update.Name = evm.Name;
                update.Mobile = evm.Mobile;
                update.Email = evm.Email;
                update.Designation = evm.Designation;
                update.Address = evm.Address;
                update.UpdatedBy = user;
                update.UpdatedOn = DateTime.Now;

                _schoolContext.Update(update);
            }
            else
            {
                var create = new Employee();
                create.Id = evm.Id;
                create.Name = evm.Name;
                create.Designation = evm.Designation;
                create.Email = evm.Email;
                create.Mobile = evm.Mobile;
                create.Address = evm.Address;
                create.CreatedBy = user;
                create.CreatedOn = DateTime.Now;

                _schoolContext.Employees.Add(create);
            }
            _schoolContext.SaveChanges();
            return evm;

        }
    }
}
