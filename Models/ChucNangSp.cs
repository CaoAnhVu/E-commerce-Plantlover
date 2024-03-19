using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class ChucNangSp
{
    [Required]
    public int MaChucNang { get; set; }
    [StringLength(150)]
    [Required] 
    public string? TenChucNang { get; set; }
    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
