using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class CheDoA
{
    public int MaCheDoAs { get; set; }

    public string? TenCheDoAs { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
