using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Filters;
using Shop.Models;
using Shop.Repository;
using System;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add Session Settings and OverRide Some Futures!
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            #endregion

            #region Add Service And Exception Filters For All Controller
            // Add services to the container & Filters.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());
            //}); 
            #endregion

            #region Custom Register Service (Dependance injection)
            builder.Services.AddDbContext<ShopContext>(
                options=>{
                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            //Register Identity With ShopDbContext
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 4;
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ShopContext>();

            //Cutom Service Register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline. And MiddelWare 
            if (!app.Environment.IsDevelopment())
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
            app.UseSession();


            #region Custom Route Name Confination Rout 
            //app.MapControllerRoute("Route1", "R1/{name}/{age:int:range(20,95):max(100):min(20):regex([])}", 
            //    new { controller="Route",action="Method1" });

            //   app.MapControllerRoute("Route1", "R1/{name}/{age:int}/{color?}",
            //new { controller = "Route", action = "Method1" });
            
            //Default For Microsoft
            //app.MapControllerRoute("Rout1", "{controller=Route}/{action=Method1}", new {controller="Route" });
            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
