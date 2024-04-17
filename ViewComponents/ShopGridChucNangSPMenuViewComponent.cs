using Cs_Plantlover.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
namespace Cs_Plantlover.ViewComponents
{
    public class ShopGridChucNangSPMenuViewComponent : ViewComponent
    {
        private readonly IChucNangSPRepository _chucnangSP;
        public ShopGridChucNangSPMenuViewComponent(IChucNangSPRepository chucnangSPRepository)
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
