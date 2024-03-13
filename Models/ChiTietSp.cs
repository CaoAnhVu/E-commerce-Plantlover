using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class ChiTietSp
{
    public int MaChiTietSp { get; set; }

    public int? MaSp { get; set; }

    public string? HinhAnh { get; set; }

    public decimal? DonGiaBan { get; set; }

    public double? GiamGia { get; set; }

    public decimal? GiaBan { get; set; }

    public int? SoLuong { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DanhMucSp? MaSpNavigation { get; set; }
}
