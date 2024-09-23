using Microsoft.EntityFrameworkCore;
using Shop.Filters;
using Shop.Models;
using Shop.Repository;

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

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
