﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Models;
using Shop.ViewModel;
using System.Security.Claims;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager)
        {
            _userManger = userManger;
            _signInManager = signInManager;
        }
        #region RegisterView
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        #endregion

        #region Register
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]//find The Token into request name "_request"

        public async Task<IActionResult> SaveRegister(RegisterViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = UserViewModel.UserName;
                appUser.PasswordHash = UserViewModel.Password;
                appUser.Address = UserViewModel.Address;

                //save into db
                IdentityResult result = await _userManger.CreateAsync(appUser, UserViewModel.Password);
                if (result.Succeeded)
                {
                    #region Add Role
                    var res= await _userManger.AddToRoleAsync(appUser,"Admin");
                    if (res.Succeeded)
                    {
                        //crete cookie
                        await _signInManager.SignInAsync(appUser, false);
                        return RedirectToAction("Index", "Department");
                    }
                    else
                    {
                        foreach (var item in res.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                    #endregion
                   
                    //TODO Need Tocheck if Data Saved or not with Error or saved Without Error 
                    
                }
                else
                {
                    //Show and send Error To View
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }


            }
            //Error So save
            return View("Register", UserViewModel);
        }

        #endregion

  

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//find The Token into request name "_request"
        public async Task<IActionResult> SaveLogin(LoginViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                //Check Found
              ApplicationUser appUser=  await _userManger.FindByNameAsync(userViewModel.Name);
              
              if (appUser != null)
              {
                   bool found =await _userManger.CheckPasswordAsync(appUser, userViewModel.Password);
                    if(found)
                    {
                        //cookie include By Default {Id,Name,Role}
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appUser.Address));
                        await _signInManager.SignInWithClaimsAsync(appUser,userViewModel.RememberMe, claims);
                        Claim AddressClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAddress");
                        return RedirectToAction("Index", "Department");
                    }
                }

              ModelState.AddModelError("", "UserNmae Or Password is Invalid");
                
                //Create Cookie
            }
            return View("Login");
        }

        #endregion

        #region Logout
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return View("Login");

        }
        #endregion
    }
}
