using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class ViTri
{
    [Required]
    public int MaViTri { get; set; }
    [Required,StringLength(150)]
    public string? TenViTri { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
