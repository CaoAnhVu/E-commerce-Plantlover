using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string? UserName { get; set; }

    public string? TenNhanVien { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? SoDt { get; set; }

    public string? DiaChi { get; set; }

    public string? ChucVu { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual User? UserNameNavigation { get; set; }
}
