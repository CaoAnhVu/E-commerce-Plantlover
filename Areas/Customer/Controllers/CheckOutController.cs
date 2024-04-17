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
    public class CheckOutController : Controller
    {
        public OrderHeader? OrderHeader { get; set; }
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;

        public CheckOutController(DoAnWebDbContext db, ILogger<HomeController> logger, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            return View(cart);
        }
    }
}
