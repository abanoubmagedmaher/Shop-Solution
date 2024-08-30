using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class DepartmentController : Controller
    {
        ShopContext context= new ShopContext();
        public IActionResult Index()
        {
            //load Employee Count using include 
            //List<Department> departmentLst=context.Department
            //    .Include(d => d.Employees).ToList();
            List<Department> departmentLst=context.Department.ToList();
            return View("Index",departmentLst);
        }
    }
}
