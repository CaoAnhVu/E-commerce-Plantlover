using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class ChiTietHoaDon
{
    [Required]
    public int MaChiTietSp { get; set; }
    [Required]
    public int MaHoaDon { get; set; }
    [Range(0, int.MaxValue)]
    [Required]
    public int? SoLuongBan { get; set; }
    [Range(0, int.MaxValue)]
    [Required]
    public decimal? DonGiaBan { get; set; }
    [Range(0, 1)]
    public double? GiamGia { get; set; }
    [StringLength(400)]
    public string? GhiChu { get; set; }

    public virtual ChiTietSp MaChiTietSpNavigation { get; set; } = null!;

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
}
