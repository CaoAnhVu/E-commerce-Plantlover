using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Models;
using Cs_Plantlover.Repository.IRepository;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Cs_Plantlover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/user")]
   /* [Authorize(Roles = SD.Role_Admin)]*/
    public class UserController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(DoAnWebDbContext db, ILogger<UserController> logger, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            IEnumerable<User> userList = _db.User.ToList();
            PagedList<User> lst = new PagedList<User>(userList, pageNumber, pageSize);
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in lst)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
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
