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
        /*[Route("")]
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
        }*/
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

            // Use a join to fetch users with their roles
            var usersWithRoles = from user in _db.User
                                 join userRole in _db.UserRoles on user.Id equals userRole.UserId
                                 join role in _db.Roles on userRole.RoleId equals role.Id
                                 select new
                                 {
                                     User = user,
                                     RoleName = role.Name
                                 };

            // Apply pagination
            var paginatedUsers = usersWithRoles.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            // Create a list of users with roles
            var userList = paginatedUsers.Select(u =>
            {
                u.User.Role = u.RoleName; // Assuming the User model has a Role property
                return u.User;
            }).ToList();

            PagedList<User> lst = new PagedList<User>(userList, pageNumber, pageSize);

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
                // Unlock the account
                user.LockoutEnd = DateTime.Now;
                TempData["Message"] = "Tài khoản đã được mở khóa thành công.";
            }
            else
            {
                // Lock the account
                user.LockoutEnd = DateTime.Now.AddYears(1000);
                TempData["Message"] = "Tài khoản đã được khóa thành công.";
            }
            // Lưu thay đổi vào cơ sở dữ liệu
            await _db.SaveChangesAsync();
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

            TempData["Message"] = "Tài khoản người dùng đã được xóa thành công.";
            return RedirectToAction(nameof(ListUser));
        }

    }
}
