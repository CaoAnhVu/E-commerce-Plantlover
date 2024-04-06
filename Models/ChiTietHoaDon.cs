using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cs_Plantlover.Models
{
    public class ChiTietHoaDon
    {
        [Required, Key]
        public int MaChiTietSP { get; set; }
        [Required]
        public int MaHoaDon { get; set; }
        [Required]
        public int SoLuongBan { get; set; }
        [Required ,Range(17,2)]
        public decimal DonGiaBan { get; set; }
        [StringLength(4000)]
        public string? GhiChu { get; set; }
        public virtual ChiTietSP MaChiTietSpNavigation { get; set; } = null!;

        public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
    }
}
