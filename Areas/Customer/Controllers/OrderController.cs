using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using Data;
using Cs_Plantlover.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cs_Plantlover.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly DoAnWebDbContext _db;

        [BindProperty]
        public OrderDetailsViewModel orderVM { get; set; }

        public OrderController(DoAnWebDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string status, int? page)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return Unauthorized();
            }

            var orderDetailsQuery = _db.OrderDetails
                                       .Include(o => o.OrderHeader)
                                       .Include(o => o.DanhMucSP)
                                       .Where(u => u.OrderHeader.UserId == claim.Value);

            switch (status)
            {
                case "pending":
                    orderDetailsQuery = orderDetailsQuery.Where(o => o.OrderHeader.PaymentStatus == SD.StatusPending);
                    break;
                case "inprocess":
                    orderDetailsQuery = orderDetailsQuery.Where(o => o.OrderHeader.OrderStatus == SD.StatusApproved ||
                                                                     o.OrderHeader.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    orderDetailsQuery = orderDetailsQuery.Where(o => o.OrderHeader.OrderStatus == SD.StatusShipped);
                    break;
                case "rejected":
                    orderDetailsQuery = orderDetailsQuery.Where(o => o.OrderHeader.OrderStatus == SD.StatusCancelled ||
                                                                     o.OrderHeader.OrderStatus == SD.StatusRefunded ||
                                                                     o.OrderHeader.OrderStatus == SD.PaymentStatusRejected);
                    break;
                default:
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var orderDetails = await orderDetailsQuery.ToPagedListAsync(pageNumber, pageSize);

            return View(orderDetails);
        }
    }
}
