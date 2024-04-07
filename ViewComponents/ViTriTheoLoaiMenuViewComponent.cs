using Cs_Plantlover.Models;
using Cs_Plantlover.Repository;
using Microsoft.AspNetCore.Mvc;
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
