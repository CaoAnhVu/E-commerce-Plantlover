using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class BlogDetail
    {
        [Required]
        public int Id { get; set; }

        
        [Display(Name = "Nhập tiêu đề bài viết")]
        public string? Title { get; set; }

        
        [Display(Name = "Ảnh cho bài viết")]
        public string? HinhAnh { get; set; }

        
        [Display(Name = "Nhập nội dung bài viết")]
        public string Description { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int MaChucNang { get; set; }
       
        public ChucNangSP? ChucNangSP { get; set; }
        public int MaViTri { get; set; }
        public ViTri? ViTri { get; set; }
    }
}
