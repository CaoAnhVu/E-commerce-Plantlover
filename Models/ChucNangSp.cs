using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class ChucNangSP
    {
        [Key,Required]
        public int MaChucNang {  get; set; }

        [Required(ErrorMessage = "Không được để tên trống"), StringLength(150)]
        [Display(Name = "Tên Chức Năng")]
        public string? TenChucNang { get; set; }
        public virtual ICollection<DanhMucSP> DanhMucSPs { get; set; } = new List<DanhMucSP>();
    }
}
