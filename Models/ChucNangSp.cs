using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class ChucNangSp
{
    public int MaChucNang { get; set; }

    public string? TenChucNang { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
