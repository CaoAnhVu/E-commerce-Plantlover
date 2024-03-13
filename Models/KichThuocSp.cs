using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class KichThuocSp
{
    public int MaKichThuoc { get; set; }

    public string? TenKichThuoc { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
