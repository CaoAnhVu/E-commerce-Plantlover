using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Areas.Customer;
using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.Models;
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cs_Plantlover.Models.Services;
using Cs_Plantlover.Services;
using Cs_Plantlover.Repository.IRepository;
using Nest;
using Stripe;
using System.Diagnostics;
using System.Security.Claims;
using X.PagedList;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Cs_Plantlover.Models.Momo;

namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        public Cart? Cart { get; set; }
        // anh xa du lieu
        [BindProperty]
        public CheckoutViewModel checkoutVM { get; set; }
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IVnPayService _vnPayService;
        private IMomoService _momoService;

        public CartController(DoAnWebDbContext db, ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signInManager, IVnPayService vnPayService, IMomoService momoService)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _vnPayService = vnPayService;
            _momoService = momoService;
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

            if (!User.Identity.IsAuthenticated)
            {
                // Chuyển hướng đến trang đăng nhập, với returnUrl
                return RedirectToAction("Login", "Account", new {area = "Identity", returnUrl });
            }
            // Chuyển đến returnUrl sau khi thêm vào giỏ hàng
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
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel checkoutVM, string FirstName, string LastName, string StreetAddress, string City, string PhoneNumber, string Village, string District, string Email, string OrderNotes, string PaymentMethod)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index");
            }

            if (PaymentMethod == "VNPay")
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = (long)(cart.Items.Sum(i => i.DanhMucSP.GiaBan * i.SoLuong) + 30000),
                    CreatedDate = DateTime.Now,
                    FullName = checkoutVM.PaymentMethod,
                    OrderId = new Random().Next(1000, 100000)
                };
                return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
            }
         
            var orderHeader = new OrderHeader
            {
                UserId = user.Id,
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(7),
                OrderTotal = (long)(cart.Items.Sum(i => i.DanhMucSP.GiaBan * i.SoLuong) + 30000), // Adding a fixed shipping cost
                OrderStatus = PaymentMethod switch
                {
                    "CashOnDelivery" => SD.StatusApproved,
                    "Momo" => SD.StatusInProcess,
                    "VNPay" => SD.StatusInProcess,
                    _ => SD.PaymentStatusRejected
                },
                PaymentStatus = PaymentMethod switch
                {
                    "CashOnDelivery" => SD.PaymentStatusDelayedPayment,
                    "Momo" => SD.PaymentStatusApproved,
                    "VNPay" => SD.PaymentStatusApproved,
                    _ => SD.PaymentStatusRejected
                },
                PhoneNumber = PhoneNumber,
                Name = user.FullName,
                StreetAddress = StreetAddress,
                Village = Village,
                Quan = user.District,
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
        
        public IActionResult PaymentFail()
        {
           
            return View();
        }
        public IActionResult Success(int id)
        {
            var order = _db.OrderHeaders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.DanhMucSP)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Pass the OrderHeader object to the view
            return View(order);
        }

        public IActionResult PaymentCallBack()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"Lỗi thanh toán VnPay : {response?.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }

            // Generate order ID and save order details
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            var user = _userManager.GetUserAsync(User).Result;

            if (cart == null || !cart.Items.Any() || user == null)
            {
                return RedirectToAction("Index");
            }

            var orderHeader = new OrderHeader
            {
                UserId = user.Id,
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(7),
                OrderTotal = (long)(cart.Items.Sum(i => i.DanhMucSP.GiaBan * i.SoLuong) + 30000), // Adding a fixed shipping cost
                OrderStatus = SD.StatusApproved,
                PaymentStatus = SD.PaymentStatusApproved,
                PhoneNumber = user.PhoneNumber,
                Name = user.FullName,
                StreetAddress = user.Address,
                Village = user.Village,
                Quan = user.District,
                City = user.City
            };

            _db.OrderHeaders.Add(orderHeader);
            _db.SaveChanges();

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

            _db.SaveChanges();

            cart.ClearAll();
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            TempData["Message"] = "Thanh toán VnPay thành công";
            return RedirectToAction("Success", new { id = orderHeader.Id });
        }
       
        public IActionResult OrderConfirmation(int id)
        {
            var order = _db.OrderHeaders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.DanhMucSP)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Pass the OrderHeader object to the view
            return View(order);
        }

    }
}
