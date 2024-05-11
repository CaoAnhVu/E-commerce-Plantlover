using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Controllers;
using Cs_Plantlover.Models;
using Cs_Plantlover.Repository.IRepository;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Cs_Plantlover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/user")]
   /* [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Customer)]*/
    public class UserController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<UserController> _logger;
        public UserController(DoAnWebDbContext db, ILogger<UserController> logger)
        {
            _db = db;
            _logger = logger;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("ListUser")]
        public IActionResult ListUser(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstuser = _db.User .AsNoTracking().OrderBy(x => x.FullName);
            PagedList<User> lst = new PagedList<User>(lstuser, pageNumber, pageSize);
            return View(lst);
        }
        [HttpPost]
        [Route("LockAccount")]
        public async Task<IActionResult> LockAccount(string id)
        {
            // Tìm người dùng theo id
            var user = await _db.User.FindAsync(id);
            if (user == null)
            {
                return RedirectToAction(nameof(ListUser));
            }

            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now;
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            // Lưu thay đổi vào cơ sở dữ liệu
            await _db.SaveChangesAsync();

            TempData["Message"] = "Tài khoản đã được khóa thành công.";
            return RedirectToAction(nameof(ListUser));
        }
        [HttpPost]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await _db.User.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            // Xóa người dùng khỏi cơ sở dữ liệu
            _db.User.Remove(user);
            await _db.SaveChangesAsync();

            TempData["Message"] = "Người dùng đã được xóa thành công.";
            return RedirectToAction(nameof(ListUser));
        }

    }
}
