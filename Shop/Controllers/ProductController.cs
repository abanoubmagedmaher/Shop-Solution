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
        public IActionResult Details(int id) {
            ProductsBL productsBL = new ProductsBL();
            Products product = productsBL.GetById(id);
            if (product== null)
            {
                View("NotFound");
            }
            return View("Details", product);
        }


      
    }
}
