using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Model;
using SchoolManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolManagementSystem.Data
{
    public class SchoolContext : IdentityDbContext
    {
        public SchoolContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Class { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet <Fee> Fees { get; set; }
        public DbSet <Teacher> Teachers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StaffSalary> StaffSalaries { get; set; }
        public DbSet<Subject> Subjects { get; set; }
     
       
    }
}
