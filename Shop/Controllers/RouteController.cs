using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Shop.Controllers
{
    public class RouteController : Controller
    {
        //Route = R1/pop/27
        //public IActionResult Method1(string name, int age,string? color)
        //{
        //    return Content($"M1 = name=>{name} & age => {age} Year");
        //}

        //call R 
        //can call R/Method1
        //or [Route("api/Method1")]
        public IActionResult Method1()
        {
            return Content("M1");
        }
        //Route = R1/Method2
        public IActionResult Method2()
        {
            return Content("M2");
        }
        public IActionResult Method3()
        {
            return Content("M3");
        }
    }
}
