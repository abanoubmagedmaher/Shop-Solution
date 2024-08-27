using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        //Public Method 
        //can not be  static
        //can not be overload

        public string ShowMsg()
        {
            return "Hello World";
        }
        //Actions 
        /*
         *String ----> ContentResult
         *view ------> ViewResult
         *Json ------> JSonResult
         *File -------> FileResult
         *NotFound ---> NotFoundResult
         *Unauthorized -> UnAuthoriResult 
        */

        public ViewResult getView()
        {
            ViewResult result=new ViewResult();
            result.ViewName = "View1";
            return result;
        }

        public IActionResult ShowMix(int x)
        {
            if (x %2 ==0)
            {
                //ViewResult result = new ViewResult();
                //result.ViewName="View1";
                //return result;
                return View("View1");
            }
            else
            {
                //ContentResult result = new ContentResult();
                //result.Content = "Hello World";
                //return result;
                return Content("Hello World");
            }
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
