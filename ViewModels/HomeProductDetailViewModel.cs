using Cs_Plantlover.Models;


namespace Cs_Plantlover.ViewModels
{
    public class HomeProductDetailViewModel
    {
        public required DanhMucSP danhMucSP { get; set; }
        public required List<ChiTietSP> chiTietSP { get; set; }
       }
}
