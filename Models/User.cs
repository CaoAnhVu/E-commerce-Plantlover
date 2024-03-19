using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cs_Plantlover.Models;

public partial class User
{
    [Required,MaxLength(50)]
    public string UserName { get; set; } = null!;
    [Required, MaxLength(50)]
    public string? PassWord { get; set; }
    [Required]
    public bool? LoaiUser { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
