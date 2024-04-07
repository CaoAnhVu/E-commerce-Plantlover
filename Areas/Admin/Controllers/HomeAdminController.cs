using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Controllers;
using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Cs_Plantlover.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HomeAdminController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeAdminController> _logger;
        public HomeAdminController(DoAnWebDbContext db, ILogger<HomeAdminController> logger)
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
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = _db.DanhMucSps.AsNoTracking().OrderBy(x => x.TenSP);
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
            TempData["Message"] = "";
            var chiTietSanPhams=_db.ChiTietSps.Where(x=>x.MaSP==maSanPham).ToList();
            if (chiTietSanPhams.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này!";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPhams=_db.ChiTietSps.Where(x=>x.MaSP==maSanPham);
            if (anhSanPhams.Any())_db.RemoveRange(anhSanPhams);
            _db.Remove(_db.DanhMucSps.Find(maSanPham));
            _db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa thành công";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");

          
        }
    }
}
