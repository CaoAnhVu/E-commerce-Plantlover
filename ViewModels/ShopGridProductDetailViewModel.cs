
using Cs_Plantlover.Models;


namespace Cs_Plantlover.ViewModels
{
    public class ShopGridProductDetailViewModel
    {
        public required DanhMucSP danhMucSP { get; set; }
        public required List<ChiTietSP> chiTietSP { get; set; }
       }
}
