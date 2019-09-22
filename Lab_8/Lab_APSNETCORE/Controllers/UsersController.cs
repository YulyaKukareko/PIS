using System;
using System.Collections.Generic;
using Lab_APSNETCORE.Models;
using Lab_APSNETCORE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_APSNETCORE.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService _usersService;
        public UsersController(UsersService usersService) => _usersService = usersService;

        [HttpGet]
        public ActionResult Index() => View();
        private List<SelectListItem> GetGenders()
        {
            var genders = Enum.GetValues(typeof(Gender));
            var result = new List<SelectListItem>();
            foreach (var gender in genders)
            {
                result.Add(new SelectListItem()
                {
                    Value = ((int)gender).ToString(),
                    Text = gender.ToString()
                });
            }
            return result;
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Genders = GetGenders();
            return View(new User());
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Error!";
                ViewBag.Genders = GetGenders();
                return View();
            }
            _usersService.Add(user);
            return RedirectToAction("Index");
        }
    }
}