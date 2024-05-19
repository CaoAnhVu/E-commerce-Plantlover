using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Areas.Customer;
using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.Models;
using Cs_Plantlover.ViewModels;
using Data;
using Cs_Plantlover.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using Stripe;
using System.Diagnostics;
using System.Security.Claims;
using X.PagedList;
using System.Threading.Tasks;
using System.Linq;

namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        public Cart? Cart { get; set; }
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CartController(DoAnWebDbContext db, ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int maSP, int quantity, string returnUrl)
        {
            var danhMucSP = await _db.DanhMucSps.Include(p => p.ChiTietSPs).FirstOrDefaultAsync(p => p.MaSP == maSP);
            var cartItem = new CartItem
            {
                DanhMucSP = danhMucSP,
                SoLuong = quantity,
            };

            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            cart.AddItem(cartItem);

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Redirect(returnUrl);
        }

        public IActionResult RemoveFromCart(int maSP)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart is not null)
            {
                cart.RemoveItem(maSP);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Clear(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart is not null)
            {
                cart.ClearAll();
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Increase(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart is not null)
            {
                cart.IncreaseOrDecreased(true, productId);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Decrease(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart != null)
            {
                cart.IncreaseOrDecreased(false, productId);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
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

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(string FirstName, string LastName, string StreetAddress, string City, string PhoneNumber, string Email, string OrderNotes, string PaymentMethod)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index");
            }

            var orderHeader = new OrderHeader
            {   
                UserId = user.Id,
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(3),
                OrderTotal = (long)(cart.Items.Sum(i => i.DanhMucSP.GiaBan * i.SoLuong) + 30000), // Adding a fixed shipping cost
                OrderStatus = "Pending",
                PaymentStatus = PaymentMethod == "CheckPayment" ? "Pending" : "Completed",
                PhoneNumber = PhoneNumber,
                Name = $"{FirstName} {LastName}",
                StreetAddress = StreetAddress,
                City = City
            };

            _db.OrderHeaders.Add(orderHeader);
            await _db.SaveChangesAsync();

            foreach (var item in cart.Items)
            {
                var orderDetails = new OrderDetails
                {
                    OrderId = orderHeader.Id,
                    MaSP = item.DanhMucSP.MaSP,
                    Count = item.SoLuong,
                    Price = (long)item.DanhMucSP.GiaBan
                };

                _db.OrderDetails.Add(orderDetails);
            }

            await _db.SaveChangesAsync();

            cart.ClearAll();
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("OrderConfirmation", new { id = orderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            var order = _db.OrderHeaders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.DanhMucSP)
                .FirstOrDefault(o => o.Id == id);

            return View(id);
        }
    }
}
