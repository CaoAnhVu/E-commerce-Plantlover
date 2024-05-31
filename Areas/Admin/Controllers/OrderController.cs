using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Models;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;
namespace Cs_Plantlover.Areas.Admin.Controllers
{
    [Area("Admin")]
    /*[Authorize(Roles = SD.Role_Admin)]*/
    /* [Authorize]*/
    public class OrderController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<OrderController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // anh xa du lieu
        [BindProperty]
        public OrderDetailsViewModel orderVM { get; set; }
        public OrderController(DoAnWebDbContext db, ILogger<OrderController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        // order process
        /*[Authorize(Roles = SD.Role_Admin)]*/
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstorder = _db.OrderHeaders.AsNoTracking().OrderBy(x => x.Id);
            PagedList<OrderHeader> lst = new PagedList<OrderHeader>(lstorder, pageNumber, pageSize);
            return View(lst);
        }
        // Details info
        public IActionResult Details(int id)
        {
            orderVM = new OrderDetailsViewModel()
            {
                orderHeader = _db.OrderHeaders.Include(u => u.User).FirstOrDefault(u => u.Id == id),
                orderDetails = _db.OrderDetails.Include(o => o.DanhMucSP).Where(o => o.OrderId == id).ToList()
            };
            return View(orderVM);
        }


        // Details pay
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Details")]
        public IActionResult Details(string stripeToken)
        {
            OrderHeader orderHeader = _db.OrderHeaders.Include(u => u.User).FirstOrDefault(u => u.Id == orderVM.orderHeader.Id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            // Assuming some other business logic needs to be done, otherwise just save the changes
            _db.SaveChanges();

            return RedirectToAction("Details", new { id = orderHeader.Id });
        }
        public IActionResult DeleteOrder(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);

            if (orderHeader == null)
            {
                return NotFound();
            }
            TempData["Success"] = "Hóa đơn đã được xóa thành công.";
            _db.OrderHeaders.Remove(orderHeader);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        // order process
        /*[Authorize(Roles = SD.Role_Admin )]*/
        public IActionResult StartProcessing(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders.Where(u => u.Id == id).FirstOrDefault();
            orderHeader.OrderStatus = SD.StatusInProcess;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //order ship
        [HttpPost]
       /* [Authorize(Roles = SD.Role_Admin )]*/
        public IActionResult ShipOrder()
        {
            OrderHeader orderHeader = _db.OrderHeaders.Where(u => u.Id == orderVM.orderHeader.Id).FirstOrDefault();
            orderHeader.TrackingNumber = orderVM.orderHeader.TrackingNumber;
            orderHeader.Carrier = orderVM.orderHeader.Carrier;
            orderHeader.OrderStatus = SD.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // order cancel
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult CancelOrder(int id)
        {
            OrderHeader orderHeader = _db.OrderHeaders.Where(u => u.Id == id).FirstOrDefault();
            if (orderHeader.PaymentStatus == SD.StatusApproved)
            {
                var options = new RefundCreateOptions
                {
                    Amount = Convert.ToInt32(orderHeader.OrderTotal * 100),
                    Reason = RefundReasons.RequestedByCustomer,
                    Charge = orderHeader.TransactionId

                };
                var service = new RefundService();
                Refund refund = service.Create(options);

                orderHeader.OrderStatus = SD.StatusRefunded;
                orderHeader.PaymentStatus = SD.StatusRefunded;
            }
            else
            {
                orderHeader.OrderStatus = SD.StatusCancelled;
                orderHeader.PaymentStatus = SD.StatusCancelled;
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //order update info
        public IActionResult UpdateOrderDetails()
        {
            var orderHEaderFromDb = _db.OrderHeaders.Where(u => u.Id == orderVM.orderHeader.Id).FirstOrDefault();
            orderHEaderFromDb.Name = orderVM.orderHeader.Name;
            orderHEaderFromDb.PhoneNumber = orderVM.orderHeader.PhoneNumber;
            orderHEaderFromDb.StreetAddress = orderVM.orderHeader.StreetAddress;
            orderHEaderFromDb.Quan = orderVM.orderHeader.User.District;
            orderHEaderFromDb.City = orderVM.orderHeader.City;
            if (orderVM.orderHeader.Carrier != null)
            {
                orderHEaderFromDb.Carrier = orderVM.orderHeader.Carrier;
            }
            if (orderVM.orderHeader.TrackingNumber != null)
            {
                orderHEaderFromDb.TrackingNumber = orderVM.orderHeader.TrackingNumber;
            }

            _db.SaveChanges();
            TempData["Error"] = "Cập nhập thành công.";
            return RedirectToAction("Details", "Order", new { id = orderHEaderFromDb.Id });
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetOrderList(string status)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(SD.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Include("User").ToList();
            }
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(u => u.UserId == claim.Value).Include("User").ToList(); 
                               
            }

            // status order
            switch (status)
            {
                case "pending":
                    orderHeaderList = orderHeaderList.Where(o => o.PaymentStatus == SD.StatusPending);
                    break;
                case "inprocess":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusApproved ||
                                                            o.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusShipped);
                    break;
                case "rejected":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == SD.StatusCancelled ||
                                                            o.OrderStatus == SD.StatusRefunded ||
                                                            o.OrderStatus == SD.PaymentStatusRejected);
                    break;
                default:
                    break;
            }


            return Json(new { data = orderHeaderList });
        }
        #endregion
    }
}
