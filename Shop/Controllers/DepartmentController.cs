using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Models;

namespace Shop.Controllers
{
    public class DepartmentController : Controller
    {
        ShopContext context= new ShopContext();
        public IActionResult Index()
        {
            //load Employee Count using include 
            List<Department> departmentLst=context.Department
               .Include(d => d.Employees).ToList();
           // List<Department> departmentLst=context.Department.ToList();
            return View("Index",departmentLst);
        }

        #region Add Department Vieww
        public IActionResult AddDept()
        {
            return View("AddDept");
        }
        #endregion

        #region Save Department into db
        public IActionResult SaveAdd(Department newDeptObj)
        {
            try
            {
                if (!string.IsNullOrEmpty(newDeptObj.Name))
                {
                    context.Department.Add(newDeptObj);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("AddDept",newDeptObj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
