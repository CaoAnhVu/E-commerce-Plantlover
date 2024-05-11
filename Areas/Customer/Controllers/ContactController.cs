using Cs_Plantlover.Areas.Customer;
using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.Models;
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using System.Diagnostics;
using X.PagedList;

namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ContactController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;

        public ContactController(DoAnWebDbContext db, ILogger<HomeController> logger, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("Contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(LeaveMessenger leaveMessenger)
        {
            if (ModelState.IsValid)
            {
                _db.LeaveMessengers.Add(leaveMessenger);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leaveMessenger);
        }
    }
}
