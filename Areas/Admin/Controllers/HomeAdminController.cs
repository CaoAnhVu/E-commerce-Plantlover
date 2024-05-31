using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Migrations;
using Cs_Plantlover.Models;
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using System.Collections.Generic;
using X.PagedList;

namespace Cs_Plantlover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/homeadmin")]
   /* [Authorize(Roles = SD.Role_Admin)]*/

    public class HomeAdminController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeAdminController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeAdminController(DoAnWebDbContext db, ILogger<HomeAdminController> logger, UserManager<User> userManager, SignInManager<User> signInManager )
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        /*public IActionResult Dashboard()
        {
            var model = new DashboardVM
            {
                SoSanPham = _db.DanhMucSps.ToList().Count,
                SoDonHang = _db.OrderDetails.ToList().Count,
                SoNguoiDung = _db.Users.ToList().Count,
                SoTinNhan = _db.LeaveMessengers.ToList().Count,
                SoChucNang = _db.ChiTietSP.ToList().Count,
            };

            return View(model);
        }*/
        [Route("")]
        public IActionResult Index()
        {
            var model = new DashboardVM
            {
                SoSanPham = _db.DanhMucSps.ToList().Count,
                SoDonHang = _db.OrderDetails.ToList().Count,
                SoNguoiDung = _db.Users.ToList().Count,
                SoTinNhan = _db.LeaveMessengers.ToList().Count,
                SoChucNang = _db.ChiTietSP.ToList().Count,
                SoBlog = _db.BlogDetails.ToList().Count,
            };

            return View(model);
            /*IEnumerable<User> userList = _db.User.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            return View(userList);*/
        }
        //quan ly danh muc san pham
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = _db.DanhMucSps.AsNoTracking().OrderBy(x => x.MaSP);
            PagedList<DanhMucSP> lst = new PagedList<DanhMucSP>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(DanhMucSP sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.DanhMucSps.Add(sanPham);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Sản phẩm đã được thêm thành công!";
                return RedirectToAction("DanhMucSanPham");

            }
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int maSanPham)
        {
            var sanPham = _db.DanhMucSps.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(DanhMucSP sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sanPham).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int maSanPham)
        {
            TempData["Message"] = "Bạn có muốn xóa sản phẩm này không?";
            var chiTietSanPhams=_db.ChiTietSps.Where(x=>x.MaSP==maSanPham).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này!";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPhams=_db.ChiTietSps.Where(x=>x.MaSP==maSanPham);
            if (anhSanPhams.Any())_db.RemoveRange(anhSanPhams);
            var sanPham = _db.DanhMucSps.Find(maSanPham);
            if (sanPham != null)
            {
                _db.Remove(sanPham);
                _db.SaveChanges();
                TempData["Message"] = "Sản phẩm đã được xóa thành công";
            }
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");


        }
        //Quan ly chuc nang san pham
        [Route("chucnangsanpham")]
        public IActionResult ChucNangSanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchucnang = _db.ChiTietSP.AsNoTracking().OrderBy(x => x.MaChucNang);
            PagedList<ChucNangSP> lst = new PagedList<ChucNangSP>(lstchucnang, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemChucNang")]
        [HttpGet]
        public IActionResult ThemChucNang()
        {
            return View(); 
        }
        [Route("ThemChucNang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemChucNang(ChucNangSP sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.ChiTietSP.Add(sanPham);
                _db.SaveChanges();
                return RedirectToAction("ChucNangSanPham");
            }
            return View(sanPham);
        }

        [Route("SuaChucNang")]
        [HttpGet]
        public IActionResult SuaChucNang(int maChucNang)
        {
            var sanPham = _db.ChiTietSP.Find(maChucNang);
            return View(sanPham);
        }

        [Route("SuaChucNang")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaChucNang(ChucNangSP sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sanPham).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ChucNangSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
       
        [Route("XoaChucNang")]
        [HttpGet]
        public IActionResult XoaChucNang(int maChucNang)
        {
            /*TempData["Message"] = "Bạn có muốn xóa sản phẩm này không?";
            var chiTietSanPhams = _db.ChiTietSP.Where(x => x.MaChucNang == maChucNang).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được chức năng này!";
                return RedirectToAction("ChucNangSanPham", "HomeAdmin");
            }*/
            var sanPham = _db.ChiTietSP.Find(maChucNang);
            if (sanPham != null)
            {
                _db.Remove(sanPham);
                _db.SaveChanges();
                TempData["Message"] = "Chức năng đã được xóa thành công";
            }
            return RedirectToAction("ChucNangSanPham", "HomeAdmin");
        }
        //vị trí sản phẩm

        [Route("vitrisanpham")]
        public IActionResult ViTriSanPham(int? page)
        {
            int pageSize = 10; 
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstvitri = _db.ViTris.AsNoTracking().OrderBy(x => x.MaViTri);
            PagedList<ViTri> lst = new PagedList<ViTri>(lstvitri, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemViTri")]
        [HttpGet]
        public IActionResult ThemViTri()
        {
            return View();
        }
        [Route("ThemViTri")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemViTri(ViTri sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.ViTris.Add(sanPham);
                _db.SaveChanges();
                return RedirectToAction("ViTriSanPham");
            }
            return View(sanPham);
        }

        [Route("SuaViTri")]
        [HttpGet]
        public IActionResult SuaViTri(int maViTri)
        {
            var sanPham = _db.ViTris.Find(maViTri);
            return View(sanPham);
        }

        [Route("SuaViTri")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaViTri(ViTri sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sanPham).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ViTriSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("XoaViTri")]
        [HttpGet]
        public IActionResult XoaViTri(int maViTri)
        {
            /*TempData["Message"] = "Bạn có muốn xóa sản phẩm này không?";
            var chiTietSanPhams = _db.ChiTietSP.Where(x => x.MaChucNang == maChucNang).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được chức năng này!";
                return RedirectToAction("ChucNangSanPham", "HomeAdmin");
            }*/
            var sanPham = _db.ViTris.Find(maViTri);
            if (sanPham != null)
            {
                _db.Remove(sanPham);
                _db.SaveChanges();
                TempData["Message"] = "Vị trí đã được xóa thành công";
            }
            return RedirectToAction("ViTriSanPham", "HomeAdmin");
        }
        //Chi tiết sản phẩm
        [Route("chitietsanpham")]
        public IActionResult ChiTietSanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstchitiet = _db.ChiTietSps.AsNoTracking().OrderBy(x => x.MaChiTietSP);
            PagedList<ChiTietSP> lst = new PagedList<ChiTietSP>(lstchitiet, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemChiTietSanPham")]
        [HttpGet]
        public IActionResult ThemChiTietSanPham()
        {
            return View();
        }


        [Route("ThemChiTietSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemChiTietSanPham(ChiTietSP sanPham)
        {
            _db.ChiTietSps.Add(sanPham);
            await _db.SaveChangesAsync();
            return RedirectToAction("ChiTietSanPham");
        }

        [Route("SuaChiTietSanPham")]
        [HttpGet]
        public IActionResult SuaChiTietSanPham(int maChiTietSP)
        {
            var sanPham = _db.ChiTietSps.Find(maChiTietSP);
            return View(sanPham);
        }

        [Route("SuaChiTietSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaChiTietSanPham(ChiTietSP sanPham)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sanPham).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("ChiTietSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("XoaChiTietSanPham")]
        [HttpGet]
        public IActionResult XoaChiTietSanPham(int maChiTietSP)
        {
          
            var sanPham = _db.ChiTietSps.Find(maChiTietSP);
            if (sanPham != null)
            {
                _db.Remove(sanPham);
                _db.SaveChanges();
                TempData["Message"] = "Chi tiết đã được xóa thành công";
            }
            return RedirectToAction("ChiTietSanPham", "HomeAdmin");
        }

        //Tin nhắn khách hàng
        [Route("LeaveMessenger")]
        public IActionResult LeaveMessenger(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstmessenger = _db.LeaveMessengers.AsNoTracking().OrderBy(x => x.Id);
            PagedList<LeaveMessenger> lst = new PagedList<LeaveMessenger>(lstmessenger, pageNumber, pageSize);
            return View(lst);
        }
        

        [Route("DetailLeaveMessenger")]
        [HttpGet]
        public IActionResult DetailLeaveMessenger(int id)
        {
            var messenger = _db.LeaveMessengers.Find(id);
            return View(messenger);
        }

        [Route("DetailLeaveMessenger")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailLeaveMessenger(LeaveMessenger messenger)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(messenger).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("LeaveMessenger", "HomeAdmin");
            }
            return View(messenger);
        }

        [Route("XoaLeaveMessenger")]
        [HttpGet]
        public IActionResult XoaLeaveMessenger(int id)
        {

            var messenger = _db.LeaveMessengers.Find(id);
            if (messenger != null)
            {
                _db.Remove(messenger);
                _db.SaveChanges();
                TempData["Message"] = "Tin nhắn đã được xóa thành công";
            }
            return RedirectToAction("LeaveMessenger", "HomeAdmin");
        }


        //quan ly Blog
        /*[Route("DanhMucBlog")]
        public IActionResult DanhMucBlog(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstblogdetail = _db.BlogDetails.Include(u => u.User).AsNoTracking().OrderBy(x => x.Id);
            PagedList<BlogDetail> lst = new PagedList<BlogDetail>(lstblogdetail, pageNumber, pageSize);
            return View(lst);
        }*/
        [Route("DanhMucBlog")]
        public IActionResult DanhMucBlog(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            // Fetch blog details with user data
            var lstblogdetail = _db.BlogDetails
                .Include(b => b.User)
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();

            // Fetch user roles and roles
            var userRoles = _db.UserRoles.AsNoTracking().ToList();
            var roles = _db.Roles.AsNoTracking().ToList();

            // Assign roles to users
            foreach (var item in lstblogdetail)
            {
                if (item.User != null)
                {
                    var roleId = userRoles.FirstOrDefault(u => u.UserId == item.User.Id)?.RoleId;
                    if (roleId != null)
                    {
                        item.User.Role = roles.FirstOrDefault(r => r.Id == roleId)?.Name;
                    }
                }
            }

            PagedList<BlogDetail> lst = new PagedList<BlogDetail>(lstblogdetail, pageNumber, pageSize);
            return View(lst);
        }

        [Route("AddBlog")]
        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }
        [Route("AddBlog")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlog(BlogDetail blog, IFormFile HinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.Length > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages/", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await HinhAnh.CopyToAsync(fileStream);
                    }

                    blog.HinhAnh = "/BlogImages/" + fileName; // Set the image path relative to the root
                }
                _db.BlogDetails.Add(blog);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Blog đã được thêm thành công!";
                return RedirectToAction("DanhMucBlog");
            }
            return View(blog);
        }
        
        [Route("EditBlog")]
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blog = _db.BlogDetails.Find(id);
            return View(blog);
        }

        [Route("EditBlog")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(int id, BlogDetail blog, IFormFile HinhAnh, string existingImagePath)
        {
            if (ModelState.IsValid)
            {
                if (HinhAnh != null && HinhAnh.Length > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BlogImages", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await HinhAnh.CopyToAsync(fileStream);
                    }

                    blog.HinhAnh = "/BlogImages/" + fileName; // Set the image path relative to the root
                }
                else
                {
                    // Use the existing image path if no new image is uploaded
                    blog.HinhAnh = existingImagePath;
                }

                blog.Id = id; // Ensure the ID is set before updating the entity state
                _db.Entry(blog).State = EntityState.Modified;

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) and return an appropriate view with error message
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    return View(blog);
                }

                return RedirectToAction("DanhMucBlog", "HomeAdmin");
            }
            return View(blog);
        }


        [Route("DeleteBlog")]
        [HttpGet]
        public IActionResult DeleteBlog(int id)
        {
            TempData["Message"] = "Bạn có muốn xóa blog này không?";
            var blogDetails = _db.BlogDetails.Where(x => x.Id == id).ToList();
            /*if (blogDetails.Count() > 0)
            {
                TempData["Message"] = "Không xóa được blog này!";
                return RedirectToAction("DanhMucBlog", "HomeAdmin");
            }*/
            var hinhAnh = _db.BlogDetails.Where(x => x.Id == id);
            if (hinhAnh.Any()) _db.RemoveRange(hinhAnh);
            var blog = _db.BlogDetails.Find(id);
            if (blog != null)
            {
                _db.Remove(blog);
                _db.SaveChanges();
                TempData["Message"] = "Blog đã được xóa thành công";
            }
            return RedirectToAction("DanhMucBlog", "HomeAdmin");
        }
    }
}
