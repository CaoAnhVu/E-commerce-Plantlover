using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class CheDoA
{
    [Required]
    public int MaCheDoAs { get; set; }
    [StringLength(150)]
    public string? TenCheDoAs { get; set; }

    public virtual ICollection<DanhMucSp> DanhMucSps { get; set; } = new List<DanhMucSp>();
}
