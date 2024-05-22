using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Areas.Customer;
using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.Models;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using Stripe;
using System.Diagnostics;
using System.Security.Claims;
using X.PagedList;

namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CheckOutController : Controller
    {
        public OrderHeader? OrderHeader { get; set; }
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // anh xa du lieu
        [BindProperty]
        public OrderDetailsViewModel orderVM { get; set; }

        public CheckOutController(DoAnWebDbContext db, ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();

            var model = new CheckoutViewModel
            {
                Cart = cart,
                User = user
            };

            return View(model);
        }

    }
}
