using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
namespace Cs_Plantlover.ViewComponents
{
    public class ViTriTheoLoaiMenuViewComponent : ViewComponent
    {
        private readonly IViTriRepository _viTri;
        public ViTriTheoLoaiMenuViewComponent(IViTriRepository viTriRepository)
        {
            _viTri = viTriRepository;
        }
        public IViewComponentResult Invoke()
        {
            var vitri = _viTri.GetAllViTri().OrderBy(x => x.MaViTri);
                return View(vitri);
        }
    }
}
