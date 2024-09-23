using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Models;
using Shop.Repository;

namespace Shop.Controllers
{
    public class DepartmentController : Controller
    {
        //ShopContext context= new ShopContext();
        IDepartmentRepository DepartmentRepo;
        public DepartmentController(IDepartmentRepository deptRepo)
        {
            DepartmentRepo = deptRepo;
        }
        #region Index
        public IActionResult Index()
        {
            //load Employee Count using include 
            List<Department> departmentLst = DepartmentRepo.GetAll("Employees");

            // List<Department> departmentLst=context.Department.ToList();
            return View("Index", departmentLst);
        } 
        #endregion

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
                    DepartmentRepo.Add(newDeptObj);

                    DepartmentRepo.Save();
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
            var Dept = DepartmentRepo.GetById(id);
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
                    var dept = DepartmentRepo.GetById(DeptFromRequest.Id);
                    if (dept != null)
                    {
                        dept.Name = DeptFromRequest.Name;
                        dept.ManagerName = DeptFromRequest.ManagerName;
                        try
                        {

                            DepartmentRepo.Save();

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
