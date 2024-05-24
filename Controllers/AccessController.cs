/*using Cs_Plantlover.Areas.Admin.Controllers;
using Cs_Plantlover.Models;
using Data;

*//*using Cs_Plantlover.Models.Authentication;*//*
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Cs_Plantlover.Controllers
{
    public class AccessController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<AccessController> _logger;
        private readonly SignInManager<User> _signInManager;

        public AccessController(DoAnWebDbContext db, ILogger<AccessController> logger, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
                return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = _db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.UserName);
                    HttpContext.Session.SetString("UserRole", u.LoaiUser ? "Admin" : "User"); // Lưu vai trò của người dùng vào session
                    if (u.LoaiUser)
                    {
                        return RedirectToAction("HomeAdmin", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _db.Users.FirstOrDefault(x => x.UserName == user.UserName);
                if (existingUser == null)
                {
                    _db.Users.Add(user); // Thêm user mới vào Database, không phải u
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ModelState.AddModelError("UserName", "Username already exists.");
                }
            }
            return View(user);
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Access");
        }

        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("UserRole") == "Admin")
            {
                return RedirectToAction("HomeAdmin", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

*/