using Cs_Plantlover.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Cs_Plantlover.Models
{
    public class DanhMucSP
    {
        [Key,Required]
        public int MaSP {  get; set; }

        [Required(ErrorMessage = "Không được để tên trống"), StringLength(4000)]
        [Display(Name = "Tên cây")]
        public string? TenSP { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mã chức năng cây")]
        public int MaChucNang { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mã vị trí cây")]
        public int MaViTri { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mã chế độ ánh sáng của cây")]
        public int MaCheDoAS { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mã vị trí cây")]
        public int MaKichThuoc { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mã môi trường sống của cây")]
        public int MaMoiTruongSong { get; set; }

        [Display(Name = "Thông tin chi tiết về cây")]

        [Required, StringLength(4000)]
        public string? MoTa { get; set; }

        [Required, StringLength(500)]
        [Display(Name = "Hình ảnh")]
        public string? AnhDaiDien { get; set; }

        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Nhập giá sản phẩm")]
        [Range(2, 100000000, ErrorMessage = "Nhập giá trong khoảng  đến 100 triệu")]
        public decimal GiaBan {  get; set; }

        
        public virtual ICollection<ChiTietSP> ChiTietSPs { get; set; } = new List<ChiTietSP>();
        public virtual ICollection<AnhSP> AnhSPs { get; set; } = new List<AnhSP>();

        public virtual CheDoAS? MaCheDoAsNavigation { get; set; }

        public virtual ChucNangSP? MaChucNangNavigation { get; set; }

        public virtual KichThuocSP? MaKichThuocNavigation { get; set; }

        public virtual MoiTruongSongSP? MaMoiTruongSongNavigation { get; set; }

        public virtual ViTri? MaViTriNavigation { get; set; }





    }
}
