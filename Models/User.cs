using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string? PassWord { get; set; }

    public bool? LoaiUser { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
