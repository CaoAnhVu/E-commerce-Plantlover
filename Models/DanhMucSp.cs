using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Cs_Plantlover.Models
{
    public class DanhMucSP
    {
        [Key,Required]
        public int MaSP {  get; set; }
        [Required, StringLength(200)]
        public String? TenSP { get; set; }
        [Required]
        public int MaChucNang { get; set; }
        [Required]
        public int MaViTri { get; set; }
        [Required]
        public int MaCheDoAS { get; set; }
        [Required]
        public int MaKichThuoc { get; set; }
        [Required]
        public int MaMoiTruongSong { get; set; }
        [Required, StringLength(4000)]
        public String? MoTa { get; set; }
        [Required, StringLength(500)]
        public String? AnhDaiDien { get; set; }
        [Required, Range(2, int.MaxValue)]
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
