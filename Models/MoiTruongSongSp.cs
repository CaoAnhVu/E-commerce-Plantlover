using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models
{
    public class MoiTruongSongSP
    {
        [Key,Required]
        public int MaMoiTruongSong { get; set; }
        [Required,StringLength(150)]
        public string? TenMoiTruongSong { get; set; }
        public virtual ICollection<DanhMucSP> DanhMucSPs { get; set; } = new List<DanhMucSP>();
    }
}
