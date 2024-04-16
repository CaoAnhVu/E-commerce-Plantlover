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
    public class CartController : Controller
    {
        public Cart? Cart { get; set; }
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;

        public CartController(DoAnWebDbContext db, ILogger<HomeController> logger, SignInManager<User> signInManager)
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

        public async Task<IActionResult> AddToCart(int maSP, int quantity)
        {
            // Giả sử bạn có phương thức lấy thông tin sản phẩm từ maSP
            var danhMucSP = await _db.DanhMucSps.Include(p => p.ChiTietSPs).FirstOrDefaultAsync(p => p.MaSP == maSP);

            var cartItem = new CartItem
            {
                DanhMucSP= danhMucSP,
                SoLuong = quantity,
            };

            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            cart.AddItem(cartItem);

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");

            if (cart is not null)
            {
                cart.RemoveItem(productId);

                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
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

                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
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

                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
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

                // Save the updated cart back to session
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            // Redirect back to the index page to reflect changes
            return RedirectToAction("Index");
        }

    }
}
