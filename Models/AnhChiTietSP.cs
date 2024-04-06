using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class AnhChiTietSP
    {
        [Required, Key]
        public int MaChiTietSP { get; set; }
        [Required,StringLength(100)]
        public String? TenFileAnh {  get; set; }
        [Range(-32768, 32767)]
        public short Vitri {  get; set; }
    }
}
