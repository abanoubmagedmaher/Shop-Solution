using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class BindController : Controller
    {
        //Binding 
       public IActionResult TestPrmitive(string name,int age)
       {
            return Content($"{name} \t {age}");
       }
       //Model Binding
       public IActionResult TestDic(Dictionary<string,string> Phones,string name)
        {
            return Content("OK");
        }

        //object 
        public IActionResult testObj(Department deptObj)
        {
            return Content("Obj");
        }
    }
}
