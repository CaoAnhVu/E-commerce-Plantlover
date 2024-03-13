using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class DanhMucSp
{
    public int MaSp { get; set; }

    public string? TenSp { get; set; }

    public int? MaChucNang { get; set; }

    public int? MaViTri { get; set; }

    public int? MaCheDoAs { get; set; }

    public int? MaKichThuoc { get; set; }

    public int? MaMoiTruongSong { get; set; }

    public string? MoTa { get; set; }

    public string? AnhDaiDien { get; set; }

    public virtual ICollection<ChiTietSp> ChiTietSps { get; set; } = new List<ChiTietSp>();

    public virtual CheDoA? MaCheDoAsNavigation { get; set; }

    public virtual ChucNangSp? MaChucNangNavigation { get; set; }

    public virtual KichThuocSp? MaKichThuocNavigation { get; set; }

    public virtual MoiTruongSongSp? MaMoiTruongSongNavigation { get; set; }

    public virtual ViTri? MaViTriNavigation { get; set; }
}
