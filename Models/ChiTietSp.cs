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
        public string? HinhAnh { get; set; }
        [Required, Range(17,2)]
        public decimal DonGiaBan { get; set; }
        [Range(2,1)]
        public decimal? GiamGia {  get; set; }
        [Range(17,2)]
        public decimal GiaBan { get; set; }
        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Nhập số cây")]
        [Range(1, 10000, ErrorMessage = "Nhập số kg trong khoảng 1 đến 10000")]
        public int SoLuong {  get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
        public virtual DanhMucSP? MaSpNavigation { get; set; }

       
    }
}
