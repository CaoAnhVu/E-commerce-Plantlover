using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class HoaDon
    {
        [Key,Required]    
        public int MaHoaDon {  get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayTao { get; set; }
        [Required]
        public int MaKhachHang { get; set; }
        [Required]
        public int MaNhanVien { get; set; }
        [ Required,Range(17,2)]
        public decimal TongTien { get; set; }
        [Required]
        public bool PhuongThucThanhToan { get; set; }
        [StringLength(400)]
        public string? GhiChu { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

        public virtual KhachHang? MaKhachHangNavigation { get; set; }

        public virtual NhanVien? MaNhanVienNavigation { get; set; }



    }
}
