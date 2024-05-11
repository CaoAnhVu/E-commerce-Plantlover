using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class NhanVien
    {
        [Key,Required]
        public int MaNhanVien { get; set; }
        [Required, MaxLength(50)]
        public string? UserName { get; set; }
        [Required, StringLength(150)]
        public string? TenNhanVien { get; set; }
        public DateOnly? NgaySinh { get; set; }
        [MaxLength(20)]
        public string? SoDt { get; set; }
        [StringLength(500)]
        public string? DiaChi { get; set; }
        [MaxLength(50)]
        public string? ChucVu { get; set; }
        [StringLength(500)]
        public string? GhiChu { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    }
}
