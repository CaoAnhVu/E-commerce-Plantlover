using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class DanhMucSp
{
    [Required]
    public int MaSp { get; set; }
    [Required, StringLength(200)]
    public string? TenSp { get; set; }
    [Required]
    public int? MaChucNang { get; set; }
    [Required]
    public int? MaViTri { get; set; }
    [Required]
    public int? MaCheDoAs { get; set; }
    [Required]
    public int? MaKichThuoc { get; set; }
    [Required]
    public int? MaMoiTruongSong { get; set; }
    [StringLength(4000)]
    public string? MoTa { get; set; }
    [Required, StringLength(500)]
    public string? AnhDaiDien { get; set; }
    [Required, Range(0, int.MaxValue)]
    public decimal? GiaBan { get; set; }

    public virtual ICollection<ChiTietSp> ChiTietSps { get; set; } = new List<ChiTietSp>();

    public virtual CheDoA? MaCheDoAsNavigation { get; set; }

    public virtual ChucNangSp? MaChucNangNavigation { get; set; }

    public virtual KichThuocSp? MaKichThuocNavigation { get; set; }

    public virtual MoiTruongSongSp? MaMoiTruongSongNavigation { get; set; }

    public virtual ViTri? MaViTriNavigation { get; set; }
}
