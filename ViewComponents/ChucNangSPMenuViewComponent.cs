using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
namespace Cs_Plantlover.ViewComponents
{
    public class ChucNangSPMenuViewComponent: ViewComponent
    {
        private readonly IChucNangSPRepository _chucnangSP;
        public ChucNangSPMenuViewComponent(IChucNangSPRepository chucnangSPRepository)
        {
            _chucnangSP = chucnangSPRepository;
        }
        public IViewComponentResult Invoke()
        {
            var chucnangsp = _chucnangSP.GetAllChucNangSP().OrderBy(x=>x.MaChucNang);
                return View(chucnangsp);
        }

    }
}
