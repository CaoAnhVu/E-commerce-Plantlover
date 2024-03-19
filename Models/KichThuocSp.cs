using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class KichThuocSp
{
    [Required]
    public int MaKichThuoc { get; set; }
    [StringLength(150)]
    public string? TenKichThuoc { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
