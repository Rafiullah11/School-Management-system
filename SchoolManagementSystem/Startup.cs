using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagementSystem.Component;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.IComponent;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<SchoolContext>(item => item.UseSqlServer(Configuration.GetConnectionString("SchoolDb")));
            services.AddIdentity<ApplicationUser, IdentityRole>(
                    opt =>
                    {
                        opt.Password.RequireDigit = true;
                        opt.Password.RequireLowercase = false;
                        opt.Password.RequireUppercase= false;
                        opt.Password.RequiredUniqueChars = 1;
                        opt.Password.RequiredLength = 3;
                        opt.Password.RequireNonAlphanumeric = false;

                    }
                    
                    ).AddEntityFrameworkStores<SchoolContext>();
            services.AddMvc(opt =>
            {
                var policey = new AuthorizationPolicyBuilder()
                                   .RequireAuthenticatedUser()
                                   .Build();
                opt.Filters.Add(new AuthorizeFilter(policey));
            }).AddXmlSerializerFormatters();

            services.AddScoped<IClassesComponent, ClassesComponent>();
            services.AddScoped<IStudentComponent, StudentComponent>();
            services.AddScoped<ISectionComponent, SectionComponent>();
            services.AddScoped<IFeeComponent,     FeeComponent>();
            services.AddScoped<ITeacherComponent, TeacherComponent>();
            services.AddScoped<IEmployeeComponent, EmployeeComponent>();
            services.AddScoped<IStaffSalaryComponent, StaffSalaryComponent>();
            services.AddScoped<ISubjectComponent, SubjectComponent>();
            services.AddScoped<IServices, Services>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
