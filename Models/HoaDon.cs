using System;
using System.Collections.Generic;

namespace Cs_Plantlover.Models;

public partial class HoaDon
{
    public int MaHoaDon { get; set; }

    public DateTime? NgayTao { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaNhanVien { get; set; }

    public decimal? TongTien { get; set; }

    public bool? PhuongThucThanhToan { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
