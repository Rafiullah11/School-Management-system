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
    public class StaffSalaryComponent : IStaffSalaryComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public StaffSalaryComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.StaffSalaries.FirstOrDefault(X => X.Id == id);
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

        public StaffSalaryViewModel GetStaffSalary(int id)
        {
            var data = _schoolContext.StaffSalaries.FirstOrDefault(X => X.Id == id);
            var get = new StaffSalaryViewModel
            {
                Id = data.Id,
                Month = data.Month,
                Salary = data.Salary,
                Date = data.Date,
                StaffId = data.StaffId,
                Year = data.Year,
                TypeId = data.TypeId
            };

            return get;

        }

        public StaffSalaryViewModel Save(StaffSalaryViewModel svm)
        {
            var user = _services.GetUserId();

            if (svm.Id>0)
            {
                var update = _schoolContext.StaffSalaries.FirstOrDefault(X => X.Id == svm.Id);
                if(svm.TeacherId != 0)
                {
                    update.StaffId = svm.TeacherId;

                }
                if(svm.EmployeeId != 0)
                {
                    update.StaffId = svm.EmployeeId;

                }
                update.Id = svm.Id;
                update.Date = svm.Date;
                update.Month = svm.Month;
                update.Year = svm.Year;
                update.Salary = svm.Salary;
                update.TypeId = svm.TypeId;
                update.UpdatedBy = user;
                update.UpdatedOn = DateTime.Now;

                _schoolContext.Update(update);
            }
            else
            {
                var create = new StaffSalary();
                create.CreatedBy = user;
                create.CreatedOn = DateTime.Now;
                create.Date = svm.Date;
                create.Id = svm.Id;
                create.Month = svm.Month;
                create.Salary = svm.Salary;
                create.TypeId = svm.TypeId;
                create.Year = svm.Year;

                if (svm.TeacherId != 0)
                {
                    create.StaffId = svm.TeacherId;

                }
                if (svm.EmployeeId != 0)
                {
                    create.StaffId = svm.EmployeeId;

                }
                _schoolContext.Add(create);
            }
            _schoolContext.SaveChanges();
            return svm;
        }

        public List<StaffSalaryViewModel> StaffSalary()
        {
            var list = _schoolContext.StaffSalaries.ToList();
            var nl = new List<StaffSalaryViewModel>();
            var name = "";
            foreach (var item in list)
            {
                if (item.TypeId == 2)
                {
                    var data = _schoolContext.Teachers.Where(x => x.Id == item.StaffId).FirstOrDefault();
                    if (data != null)
                    {
                        name = data.Name;
                    }
                    else
                    {
                        name = "";
                    }
                }
                if (item.TypeId == 1)
                {
                    var data = _schoolContext.Employees.Where(x => x.Id == item.StaffId).FirstOrDefault();
                    if (data != null)
                    {
                        name = data.Name;
                    }
                    else
                    {
                        name = "";
                    }
                }
                
                var typeName = "";
                if (item.TypeId == 1)
                {
                    typeName = "Employee";
                }
                if (item.TypeId == 2)
                {
                    typeName = "Teacher";
                }

                var month = "";
                if (item.Month == 0){month = "Select";}
                if (item.Month == 1){month = "Jan";}
                if (item.Month == 2){month = "Feb";}
                if (item.Month == 3){month = "Mar";}
                if (item.Month == 4){month = "Apr";}
                if (item.Month == 5){month = "May";}
                if (item.Month == 6){month = "Jun";}
                if (item.Month == 7){month = "Jul";}
                if (item.Month == 8){month = "Aug";}
                if (item.Month == 9){month = "Sep";}
                if (item.Month == 10){month = "Oct";}
                if (item.Month == 11){month = "Nov";}
                if (item.Month == 12){month = "Dec";}
                nl.Add(new StaffSalaryViewModel()
                {
                    Id = item.Id,
                    StaffId = item.StaffId,
                    TypeId = item.TypeId,
                    Year = item.Year,
                    Month = item.Month,
                    Salary = item.Salary,
                    Date = item.Date,
                    TypeName = typeName,
                    Name = name,
                    MonthName=month

                }) ;
            }
            return nl;
        }
    }
}
