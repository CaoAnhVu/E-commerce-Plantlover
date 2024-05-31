using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Models;
/*using Cs_Plantlover.Models.Authentication;*/
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    /*[Authorize(Roles = SD.Role_Customer)]*/
    public class HomeController : Controller
    {
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;        

        public HomeController(DoAnWebDbContext db, ILogger<HomeController> logger, SignInManager<User> signInManager)
        {
            _db = db;
            _logger = logger;
            _signInManager = signInManager;
        }
        /*[Authentication]*/
        public IActionResult Index( int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = _db.DanhMucSps.AsNoTracking().OrderBy(x => x.MaSP);
            PagedList<DanhMucSP> lst = new PagedList<DanhMucSP>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        /* [Authentication]*/
        /*[Route("Sanphamtheoloai")]*/
        public IActionResult SanPhamTheoLoai(int? machucnang, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = _db.DanhMucSps.AsNoTracking().Where(x => x.MaChucNang == machucnang).OrderBy(x => x.TenSP);
            PagedList<DanhMucSP> lst = new PagedList<DanhMucSP>(lstsanpham, pageNumber, pageSize);
            ViewBag.machucnang = machucnang;
            return View(lst);
        }
        /*[Route("SanPhamTheoViTri")]*/
        public IActionResult SanPhamTheoViTri(int? mavitri, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            List<DanhMucSP> lstsanpham=_db.DanhMucSps.Where(x =>x.MaViTri==mavitri).OrderBy(x=> x.TenSP).ToList();
            PagedList<DanhMucSP> lst = new PagedList<DanhMucSP>(lstsanpham, pageNumber, pageSize);
            ViewBag.mavitri = mavitri;
            return View(lst);
        }
        /*public IActionResult SanPhamTheoViTri(int? mavitri, int? machucnang, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = _db.DanhMucSps.AsNoTracking();*//*.Where(x => x.MaViTri == mavitri && x => x.MaChucNang == machucnang)*//*
            if (mavitri != null)
            {
                lstsanpham = (IOrderedQueryable<DanhMucSP>)lstsanpham.Where(x => x.MaViTri == mavitri);
            }
            if (machucnang != null)
            {
                lstsanpham = (IOrderedQueryable<DanhMucSP>)lstsanpham.Where(x => x.MaChucNang == machucnang);
            }
            lstsanpham = lstsanpham.OrderBy(x => x.TenSP);
            PagedList<DanhMucSP> lst = new PagedList<DanhMucSP>(lstsanpham, pageNumber, pageSize);
            ViewBag.mavitri = mavitri;
            return View(lst);
        }*/

        [Route("Chitietsanpham")]
        public IActionResult ChiTietSanPham(int maSP)
        {
            var sanPham = _db.DanhMucSps.SingleOrDefault(x => x.MaSP == maSP);
            var anhSanPham = _db.ChiTietSps.Where(x => x.MaSP == maSP).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);

            /*DanhMucSP sanPham = _db.DanhMucSps.Find(maSP);
            var anhSanPham = _db.ChiTietSps.Where(x => x.MaSP == maSP).ToList();
            if (sanPham != null)
            {
                ViewBag.anhSanPham = anhSanPham;
                return View(sanPham);

            }
            return NotFound();*/
        }
        /*[Authentication]*/
        [Route("ProductDetail")]
        public IActionResult ProductDetail(int maSP)
        {
            var sanPham = _db.DanhMucSps.SingleOrDefault(x => x.MaSP == maSP);
            var anhSanPham = _db.ChiTietSps.Where(x => x.MaSP == maSP).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel { danhMucSP = sanPham, chiTietSP = anhSanPham };
            return View(homeProductDetailViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Search(string keywords, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            IQueryable<DanhMucSP> lstsanpham;

            if (string.IsNullOrEmpty(keywords))
            {
                // Nếu từ khóa tìm kiếm không được cung cấp, hiển thị tất cả sản phẩm
                lstsanpham = _db.DanhMucSps.AsNoTracking().OrderBy(x => x.TenSP);
            }
            else
            {
                // Nếu có từ khóa tìm kiếm, lấy danh sách các sản phẩm phù hợp
                lstsanpham = _db.DanhMucSps.AsNoTracking()
            .Where(x => x.TenSP.Contains(keywords) || x.MoTa.Contains(keywords) || x.MaChucNang.ToString().Contains(keywords))
            .OrderBy(x => x.TenSP);


            }

            PagedList<DanhMucSP> lst = new PagedList<DanhMucSP>(lstsanpham, pageNumber, pageSize);

            return View("SanPhamTheoLoai", lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
