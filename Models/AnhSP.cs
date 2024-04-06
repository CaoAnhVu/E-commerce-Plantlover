using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class AnhSP
    {
        [Key,Required]
        public int MaAnhSP { get; set; }
        [Required]
        public int MaSP { get; set; }
        [Required, StringLength(100)]
        public String? TenFileAnh { get; set; }
        [Range(-32768, 32767)]
        public short? Vitri { get; set; }
        public DanhMucSP? DanhMucSP { get; set; }
    }
}
