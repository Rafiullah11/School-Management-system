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
    public class FeeComponent : IFeeComponent
    {
        private readonly SchoolContext _schoolContext;
        private readonly IServices _services;

        public FeeComponent(SchoolContext schoolContext, IServices services)
        {
            _schoolContext = schoolContext;
            _services = services;
        }
        public bool Delete(int id)
        {
            var del = _schoolContext.Fees.FirstOrDefault(X => X.Id == id);
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

        public FeeViewModel GetFee(int id)
        {
            var data= _schoolContext.Fees.FirstOrDefault(X => X.Id == id);
            var get = new FeeViewModel();
            get.Id = data.Id;
            get.Fees = data.Fees;
            get.ClassId = data.ClassId;
            get.SectionId = data.SectionId;
            get.StudentId = data.StudentId;
            get.MonthId = data.MonthId;

            return get;
        }

        public List<FeeViewModel> Index()
        {
            var list = _schoolContext.Fees.ToList();
            var nl = new List<FeeViewModel>();
            foreach (var item in list)
            {
                var cls = _schoolContext.Class.FirstOrDefault(X => X.Id == item.ClassId);
                var std = _schoolContext.Students.FirstOrDefault(X => X.Id == item.StudentId);
                var sec = _schoolContext.Sections.FirstOrDefault(X => X.Id == item.SectionId);
                var month = "";
                if (item.MonthId == 0)
                {
                    month = "";
                }
                if (item.MonthId == 1)
                {
                    month = "Jan";
                }
                if (item.MonthId == 2)
                {
                    month = "Feb";
                }
                if (item.MonthId == 3)
                {
                    month = "Mar";
                }
                if (item.MonthId == 4)
                {
                    month = "Apr";
                }
                if (item.MonthId == 5)
                {
                    month = "May";
                }
                if (item.MonthId == 6)
                {
                    month = "Jun";
                }
                if (item.MonthId == 7)
                {
                    month = "Jul";
                }
                if (item.MonthId == 8)
                {
                    month = "Aug";
                }
                if (item.MonthId == 9)
                {
                    month = "Sep";
                }
                if (item.MonthId == 10)
                {
                    month = "Oct";
                }
                if (item.MonthId == 11)
                {
                    month = "Nov";
                }
                if (item.MonthId == 12)
                {
                    month = "Dec";
                }
                nl.Add(new FeeViewModel()
                {
                    Id = item.Id,
                    Fees = item.Fees,
                    ClassId = item.ClassId,
                    ClassName= cls.Name,
                    SectionId = item.SectionId,
                    SectionName= sec.Name,
                    StudentId = item.StudentId,
                    StudentName=std.Name,
                    MonthId = item.MonthId,
                    Month=month
                });
            }
            return nl;
        }

        public FeeViewModel Save(FeeViewModel fvm)
        {
            var user = _services.GetUserId();
            if (fvm.Id<0)
            {
                var update = _schoolContext.Fees.FirstOrDefault(X => X.Id == fvm.Id);
                update.Id = fvm.Id;
                update.Fees = fvm.Fees;
                update.ClassId = fvm.ClassId;
                update.SectionId = fvm.SectionId;
                update.StudentId = fvm.StudentId;
                update.MonthId = fvm.MonthId;
                update.UpdatedBy = user;
                update.UpdatedOn = DateTime.Now;

                _schoolContext.Fees.Update(update);
            }
            else
            {
                var create = new Fee();
                create.Id = fvm.Id;
                create.Fees = fvm.Fees;
                create.ClassId = fvm.ClassId;
                create.SectionId = fvm.SectionId;
                create.StudentId = fvm.StudentId;
                create.MonthId = fvm.MonthId;
                create.CreatedBy = user;
                create.CreatedOn = DateTime.Now;

                _schoolContext.Fees.Add(create);
            }
            _schoolContext.SaveChanges();
            return fvm;
        }
    }
}
