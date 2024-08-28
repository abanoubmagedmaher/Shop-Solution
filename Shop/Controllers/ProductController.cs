using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
      ///Product/getAll
      
      public IActionResult GetAll()
      {
            ProductsBL productsBL = new ProductsBL();
            List<Products> ProductLstModel = productsBL.GetAll();
            return View("GetAll",ProductLstModel);
      }
        public IActionResult GetById(int id) {
            ProductsBL productsBL = new ProductsBL();
            var product = productsBL.GetById(id);
            return View("GetById", product);
        }


      
    }
}
