using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class ViTri
    {
        [Key,Required]
        public int MaViTri { get; set; }
        [Required, StringLength(150)]
        public string? TenViTri { get; set; }
        public virtual ICollection<DanhMucSP> DanhMucSPs { get; set; } = new List<DanhMucSP>();
    }
}
