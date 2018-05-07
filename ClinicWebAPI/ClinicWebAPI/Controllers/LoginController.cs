using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationService authService;

        public LoginController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var userNotification = authService.Login(Username, Password);
            if (userNotification.HasErrors() || userNotification.GetResult() == null)
            {
                ViewData["Errors"] = userNotification.GetErrors();
                return View("Error");
            }
            var user = userNotification.GetResult();
            switch(user.GetType())
            {
                case "admin": return RedirectToAction("Index", "User");
                case "doctor": return RedirectToAction("Index", "Doctor");
                case "secretary": return RedirectToAction("Patients", "Clinic");
                default:
                    return StatusCode(404);
            }
        }

        public ActionResult Error(List<string> errors)
        {
            return View();
        }
    }
}