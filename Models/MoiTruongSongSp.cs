using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class MoiTruongSongSp
{
    [Required]
    public int MaMoiTruongSong { get; set; }
    [StringLength(150)]
    public string? TenMoiTruongSong { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
