using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class MoiTruongSongSp
{
    public int MaMoiTruongSong { get; set; }

    public string? TenMoiTruongSong { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
