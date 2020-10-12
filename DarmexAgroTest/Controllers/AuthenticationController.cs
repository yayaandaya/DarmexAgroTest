using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarmexAgroTest.Models;
using DarmexAgroTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DarmexAgroTest.Controllers
{
    public class AuthenticationController : Controller
    {
        private DarmexAgroDbContext _darmexAgroDbContext;

        public AuthenticationController(DarmexAgroDbContext darmexAgroDbContext)
        {
            _darmexAgroDbContext = darmexAgroDbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveRegistration([FromBody] User user)
        {
            var authService = new AuthService(_darmexAgroDbContext);
            var returnVal = authService.Register(user);

            return Json(new { returnVal.status, returnVal.remarks });
        }

        [HttpPost]
        public ActionResult LoginAuthentication([FromBody] User user)
        {
            var authService = new AuthService(_darmexAgroDbContext);
            bool auth = authService.VerifyPassword(user);

            if (auth)
            {
                User userProfile = authService.GetDataUser(user.Username);

                HttpContext.Session.SetString("UserId", userProfile.UserId.ToString());
                HttpContext.Session.SetString("Username", userProfile.Username);

                return Json(new { status = true, remarks = "Login Successfull." });
            }
            else
            {
                return Json(new { status = false, remarks = "Login Failed." });
            }
        }
    }
}