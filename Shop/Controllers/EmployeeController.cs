using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Repository;
using Shop.ViewModel;

namespace Shop.Controllers
{
    public class EmployeeController : Controller
    {
        //ShopContext dbContext= new ShopContext();
        IDepartmentRepository DepartmentRepo;
        IEmployeeRepository EmployeeRepo;
        public EmployeeController(IDepartmentRepository departmentRepo,IEmployeeRepository employeeRepo)
        {
            DepartmentRepo= departmentRepo;
            EmployeeRepo= employeeRepo;
        }
        #region Details
        //public IActionResult Details(int id)
        //{

           //var EmpModel = EmployeeRepo.GetById();

        //    string Msg = $"Hello {EmpModel?.Name}";
        //    int Temp = 50;
        //    List<string> branches = new List<string>();
        //    branches.Add("Cairo");
        //    branches.Add("Alex");
        //    ViewData["Msg"] = Msg;
        //    ViewData["Temp"] = Temp;
        //    ViewData["branches"] = branches;

        //    ViewBag.color = "red";

        //    return View("Details", EmpModel);
        //}

        //public IActionResult DetailsVM(int id)
        //{
        //    var EmpModel = dbContext.Employee.Include(d => d.Department)
        //        .FirstOrDefault(x => x.Id == id);
        //    List<string> branches = new List<string>();
        //    branches.Add("Cairo");
        //    branches.Add("Alex");
        //    //Decleare View model
        //    EmpDeptColorTempMsgBranchViewModel EmpVM = new EmpDeptColorTempMsgBranchViewModel();
        //    EmpVM.EmpName = EmpModel.Name;
        //    EmpVM.DeptName = EmpModel.Department.Name;
        //    EmpVM.Color = "red";
        //    EmpVM.Temp = 50;
        //    EmpVM.Branches = branches;

        //    //Mapping

        //    return View("DetailsVM", EmpVM);
        //} 
        #endregion

        #region Index

        public IActionResult Index()
        {
            var lst = EmployeeRepo.GetAll();
            return View("Index", lst);
        }

        #endregion

        #region Add New Employee
        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewData["DeptList"] = DepartmentRepo.GetAll();
            return View("AddEmployee");
        }

        [HttpPost]
        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid && emp.DepartmentID != 0)
            {
                // Custom Validation 

                EmployeeRepo.Add(emp);
                EmployeeRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("DepartmentID", "Must Select Department ");
            }
           

            ViewBag.DeptList = DepartmentRepo.GetAll();
            return View("AddEmployee", emp);
            
        }
        #endregion

        #region Edit
        // 1-) Handel btn-Edit-Link
        public IActionResult Edit(int id)
        {
            var emp = EmployeeRepo.GetById(id);
            if (emp != null)
            {
                List<Department> DepartmantList = DepartmentRepo.GetAll();
                //---------- Create View Model And Auto Mapper
                EmpWithDeptListViewModel EmpViewModel = new EmpWithDeptListViewModel();
                EmpViewModel.Id = emp.Id;
                EmpViewModel.Name = emp.Name;
                EmpViewModel.Age = emp.Age;
                EmpViewModel.Address = emp.Address;
                EmpViewModel.Mobile = emp.Mobile;
                EmpViewModel.WhatsAppNumber = emp.WhatsAppNumber;
                EmpViewModel.Sallary = emp.Sallary;
                EmpViewModel.JobTitle = emp.JobTitle;
                EmpViewModel.ImageURL = emp.ImageURL;
                EmpViewModel.DepartmentID = emp.DepartmentID;

                EmpViewModel.DeptLst = DepartmantList;

                return View("Edit", EmpViewModel);
            }
            return View("NotFound");

        }

        // 2-) Save Edit
        [HttpPost]
        public IActionResult SaveEdit(int id, EmpWithDeptListViewModel emp)
        {
            if (emp.Name != null)
            {

                var EmpFromdb = EmployeeRepo.GetById(emp.Id);
                EmpFromdb.Name = emp.Name;
                EmpFromdb.Age = emp.Age;
                EmpFromdb.Address = emp.Address;
                EmpFromdb.Mobile = emp.Mobile;
                EmpFromdb.WhatsAppNumber = emp.WhatsAppNumber;
                EmpFromdb.ImageURL = emp.ImageURL;
                EmpFromdb.DepartmentID = emp.DepartmentID;
                EmpFromdb.Id = emp.Id;
                EmployeeRepo.Update(EmpFromdb);
                EmployeeRepo.Save();
                //dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            emp.DeptLst = DepartmentRepo.GetAll();
            return View("Edit", emp);
        }


        #endregion

        #region DeleteEmployee

        #endregion

        #region Search by Name or Mobile or Number or address or .....

        #endregion

        #region ajex call Validation
        public IActionResult CheckUniqueEmpName(string Name,string Mobile)
        {
            var checkEmpName= EmployeeRepo.GetAll().FirstOrDefault(e => e.Name == Name & e.Mobile== Mobile);
            if (checkEmpName != null)
            {
                return Json(false);
            }
            return Json(true);


        }
        #endregion


    }
}
