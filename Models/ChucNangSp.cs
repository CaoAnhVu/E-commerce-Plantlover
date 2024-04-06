using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class ChucNangSP
    {
        [Key,Required]
        public int MaChucNang {  get; set; }
        [Required, StringLength(150)]
        public String? TenChucNang { get; set; }
        public virtual ICollection<DanhMucSP> DanhMucSPs { get; set; } = new List<DanhMucSP>();
    }
}
