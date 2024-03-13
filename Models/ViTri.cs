using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class ViTri
{
    public int MaViTri { get; set; }

    public string? TenViTri { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
