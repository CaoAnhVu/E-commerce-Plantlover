using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class KhachHang
    {
        [Key,Required]
        public int MaKhachHang { get; set; }
        [Required, MaxLength(50)]
        public string? UserName { get; set; }
        [Required, StringLength(150)]
        public string? TenKhachHang { get; set; }
        public DateOnly? NgaySinh { get; set; }
        [MaxLength(50)]
        public string? SoDT { get; set; }
        [Required,StringLength(500)]
        public string? DiaChi { get; set; }
        [StringLength(500)]
        public string? GhiChu { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

       /* public virtual User? UserNameNavigation { get; set; }*/


    }
}
