using Cs_Plantlover.Areas.Admin.Models;
using Cs_Plantlover.Models;
using Cs_Plantlover.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace Cs_Plantlover.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BlogController : Controller
    {
        [BindProperty]
        public BlogDetailVM blogDetailVM { get; set; }
        private readonly DoAnWebDbContext _db;
        private readonly ILogger<BlogController> _logger;

        public BlogController(DoAnWebDbContext db, ILogger<BlogController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstblog = _db.BlogDetails.AsNoTracking().OrderBy(x => x.Id);
            PagedList<BlogDetail> lst = new PagedList<BlogDetail>(lstblog, pageNumber, pageSize);
            return View(lst);
        }
        [Route("BlogDetail")]
        public IActionResult BlogDetail(int id, int maChucNang, string fullName, int maViTri)
        {
            var blog = _db.BlogDetails.SingleOrDefault(x => x.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            var details = _db.ChiTietSP.Where(x => x.MaChucNang == maChucNang).ToList();
            var user = _db.Users.Where(x => x.FullName == fullName).ToList();
            var viTri = _db.ViTris.Where(x => x.MaViTri == maViTri).ToList();
            var blogDetailVM = new BlogDetailVM { blogDetail = blog, user = user, chucNangSP = details, viTri = viTri };
            return View(blogDetailVM);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string keywords, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            IQueryable<BlogDetail> lstblog;

            if (string.IsNullOrEmpty(keywords))
            {
                lstblog = _db.BlogDetails.AsNoTracking().OrderBy(x => x.Id);
            }
            else
            {
                lstblog = _db.BlogDetails.AsNoTracking()
                    .Where(x => x.Title.Contains(keywords) || x.Description.Contains(keywords) || x.ChucNangSP.TenChucNang.ToString().Contains(keywords))
                    .OrderBy(x => x.Id);
            }

            PagedList<BlogDetail> lst = new PagedList<BlogDetail>(lstblog, pageNumber, pageSize);

            return View("Index", lst);
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
