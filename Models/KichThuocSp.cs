using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class KichThuocSP
    {
        [Key,Required]
        public int MaKichThuoc { get; set; }
        [Required,StringLength(150)]
        public string? TenKichThuoc { get; set; }

        public virtual ICollection<DanhMucSP> DanhMucSPs { get; set; } = new List<DanhMucSP>();
    }
}
