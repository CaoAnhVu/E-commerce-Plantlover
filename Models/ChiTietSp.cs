using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class ChiTietSp
{
    [Required]
    public int MaChiTietSp { get; set; }
    [Required]
    public int? MaSp { get; set; }
    [StringLength(500)]
    public string? HinhAnh { get; set; }
    [Range(0, int.MaxValue)]
    [Required]
    public decimal? DonGiaBan { get; set; }
    [Range(0, 1)]
    public double? GiamGia { get; set; }
    [Range (0, int.MaxValue)]
    public decimal? GiaBan { get; set; }
    [Required, Range (0, int.MaxValue)]
    public int? SoLuong { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DanhMucSp? MaSpNavigation { get; set; }
}
