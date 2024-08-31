using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.ViewModel;

namespace Shop.Controllers
{
    public class EmployeeController : Controller
    {
        ShopContext dbContext= new ShopContext();
        public IActionResult Details(int id)
        {
            
            var EmpModel = dbContext.Employee.FirstOrDefault(x => x.Id == id);

            string Msg = $"Hello {EmpModel?.Name}";
            int Temp = 50;
            List<string> branches = new List<string>();
            branches.Add("Cairo");
            branches.Add("Alex");
            ViewData["Msg"] = Msg;
            ViewData["Temp"] = Temp;
            ViewData["branches"] = branches;

            ViewBag.color = "red";

            return View("Details", EmpModel);
        }

        public IActionResult DetailsVM(int id)
        {
            var EmpModel = dbContext.Employee.Include(d=>d.Department)
                .FirstOrDefault(x=>x.Id==id);
            List<string> branches = new List<string>();
            branches.Add("Cairo");
            branches.Add("Alex");
            //Decleare View model
            EmpDeptColorTempMsgBranchViewModel EmpVM = new EmpDeptColorTempMsgBranchViewModel();
            EmpVM.EmpName = EmpModel.Name;
            EmpVM.DeptName = EmpModel.Department.Name;
            EmpVM.Color = "red";
            EmpVM.Temp = 50;
            EmpVM.Branches = branches;

            //Mapping

            return View("DetailsVM", EmpVM);
        }
    }
}
