using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class StateController : Controller
    {
        #region Client Side Session
        public IActionResult SetSession(string Name)
        {
            //logic
            HttpContext.Session.SetString("Name", Name);
            HttpContext.Session.SetInt32("Age", 25);
            return Content("Data Session Save Success");
        }

        public IActionResult GetSession()
        {
            //Logic
            string n = HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"Name: {n} \t Age: {a}");
        }
        #endregion

        #region Server Side Cookies

        public IActionResult SetCookie()
        {
            #region Setting For Presistent Cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);

            #endregion
            #region Session Cookiew it will end When Session Expire or Deleted !
            //HttpContext.Response.Cookies.Append("Name", "BeBo");

            //HttpContext.Response.Cookies.Append("Age", "27"); 
            #endregion
            #region Presistent Cookie
            HttpContext.Response.Cookies.Append("Name", "BeBo");
            HttpContext.Response.Cookies.Append("Age", "27", options); 
            #endregion
            return Content("Cookie Save");
        }

        public IActionResult GetCookie()
        {
            var name= HttpContext.Request.Cookies["Name"];
            var age = HttpContext.Request.Cookies["Age"];
            return Content($"Name:- {name} , Age:- {age}");
        }


        #endregion

    }
}
