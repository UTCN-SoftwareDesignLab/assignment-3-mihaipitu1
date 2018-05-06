using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicWebAPI.Models;
using ClinicWebAPI.Models.Validators;
using ClinicWebAPI.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    public class UserController : Controller
    {
        private IAdminService adminService;

        public UserController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = adminService.GetUsers();
            return View(users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            Notification<bool> notifier = adminService.Register(user);
            if (!notifier.GetResult())
            {
                ViewData["Errors"] = notifier.GetErrors();
                return View("Error");
            }
            return RedirectToAction("Index", "User");
        }
        
        public ActionResult Edit(int id)
        {
            var user = adminService.GetUserById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            adminService.UpdateUser(user);
            return RedirectToAction("Index", "User");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = adminService.GetUserById(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            adminService.DeleteUser(user);
            return RedirectToAction("Index", "User");
        }
    }
}