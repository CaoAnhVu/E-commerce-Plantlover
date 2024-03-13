using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class ChiTietHoaDon
{
    public int MaChiTietSp { get; set; }

    public int MaHoaDon { get; set; }

    public int? SoLuongBan { get; set; }

    public decimal? DonGiaBan { get; set; }

    public double? GiamGia { get; set; }

    public string? GhiChu { get; set; }

    public virtual ChiTietSp MaChiTietSpNavigation { get; set; } = null!;

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
}
