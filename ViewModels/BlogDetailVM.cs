using Cs_Plantlover.Models;


namespace Cs_Plantlover.ViewModels
{
    public class BlogDetailVM
    {
        public required BlogDetail blogDetail { get; set; }
        public required List<User> user { get; set; }
        public required List<ViTri> viTri { get; set; }
        public required List<ChucNangSP> chucNangSP { get; set; }
        
    }
}
