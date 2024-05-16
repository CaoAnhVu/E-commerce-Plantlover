using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Cs_Plantlover.Models
{
    public class ChiTietSP
    {
        [Key,Required]
        public int MaChiTietSP { get; set; }

        [Required(ErrorMessage = "Không được để mã sản phẩm trống")]
        [Display(Name = "Mã sản phẩm")]
        public int MaSP { get; set; }

        [Required(ErrorMessage = "Không được để hình ảnh trống"), StringLength(500)]
        [Display(Name = "Hình ảnh")]
        [AllowNull]
        public string? HinhAnh { get; set; }

        public List <string>? HinhAnhs { get; set; }

        [Display(Name = "Số lượng / đơn giá")]
        [Required(ErrorMessage = "Nhập số lượng đơn giá")]
        [Range(1, 100, ErrorMessage = "Nhập giá trong khoảng  đến 100")]
        public decimal DonGiaBan { get; set; }

        [Range(1,2)]
        [Display(Name = "Giảm giá")]
        public decimal? GiamGia {  get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Nhập giá sản phẩm")]
        [Range(2, 100000000, ErrorMessage = "Nhập giá trong khoảng  đến 100 triệu")]
        public decimal GiaBan { get; set; }

        [Display(Name = "Số Lượng")]
        [Required(ErrorMessage = "Nhập số cây")]
        [Range(1, 10000, ErrorMessage = "Nhập số kg trong khoảng 1 đến 10000 cây")]
        public int SoLuong {  get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
        public virtual DanhMucSP? MaSpNavigation { get; set; }

       
    }
}
