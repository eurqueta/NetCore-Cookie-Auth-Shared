using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Areas.Identity;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        UserConfigurator _userManager;

        public AccountController(UserConfigurator userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                //authenticate

                _userManager.SignIn(this.HttpContext);
                return RedirectToAction("Search", "Home", null);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("summary", ex.Message);
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userManager.SignOut(this.HttpContext);

            return RedirectToAction("Index", "Home", null);
        }
    }
}