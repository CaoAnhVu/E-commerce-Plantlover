using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;


namespace Cs_Plantlover.ViewComponents
{
    public class CartWidget: ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
           
            return View(HttpContext.Session.GetObjectFromJson<Cart>("Cart"));
        }

    }
}
