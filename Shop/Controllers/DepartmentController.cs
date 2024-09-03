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
        [HttpPost]
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

        #region EditDepartmentById

        public IActionResult EditDepartmentById(int id)
        {
            var Dept = context.Department.Include("Employees").FirstOrDefault(d => d.Id == id);
            if (Dept != null)
            {
                return View("EditDepartmentById", Dept);

            }
            return View("NotFound");
        }

        public IActionResult SaveEdit(Department DeptFromRequest)
        {
            try
            {
                if (DeptFromRequest != null)
                {
                    var dept = context.Department.
                         FirstOrDefault(d => d.Id == DeptFromRequest.Id);
                    if (dept != null)
                    {
                        dept.Name = DeptFromRequest.Name;
                        dept.ManagerName = DeptFromRequest.ManagerName;
                        try
                        {

                            context.SaveChanges();

                        }
                        catch (Exception)
                        {

                            return View("EditDepartmentById", DeptFromRequest);
                        }
                        return RedirectToAction("Index");
                    }
                }

                return View("EditDepartmentById", DeptFromRequest);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
