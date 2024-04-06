using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class ChiTietSP
    {
        [Key,Required]
        public int MaChiTietSP { get; set; }
        [Required]
        public int MaSP { get; set; }
        [Required, StringLength(500)]
        public String? HinhAnh { get; set; }
        [Required, Range(17,2)]
        public decimal DonGiaBan { get; set; }
        [Range(2,1)]
        public decimal? GiamGia {  get; set; }
        [Range(17,2)]
        public decimal GiaBan { get; set; }
        [Required]
        public int SoLuong {  get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
        public virtual ICollection<AnhChiTietSP> AnhChiTietSPs { get; set; } = new List<AnhChiTietSP>();
        public virtual DanhMucSP? MaSpNavigation { get; set; }

    }
}
