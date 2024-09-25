using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModel;

namespace Shop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                //save db
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ViewBag.success = true;
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View("AddRole", roleViewModel);
        }

    }
}
