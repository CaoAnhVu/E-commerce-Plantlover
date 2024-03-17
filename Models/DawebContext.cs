using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cs_Plantlover.Models;

public partial class DawebContext : DbContext
{
    public DawebContext()
    {
    }

    public DawebContext(DbContextOptions<DawebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheDoA> CheDoAs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietSp> ChiTietSps { get; set; }

    public virtual DbSet<ChucNangSp> ChucNangSps { get; set; }

    public virtual DbSet<DanhMucSp> DanhMucSps { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KichThuocSp> KichThuocSps { get; set; }

    public virtual DbSet<MoiTruongSongSp> MoiTruongSongSps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViTri> ViTris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.Entity<CheDoA>(entity =>
        {
            entity.HasKey(e => e.MaCheDoAs);

            entity.ToTable("CheDoAS");

            entity.Property(e => e.MaCheDoAs).HasColumnName("MaCheDoAS");
            entity.Property(e => e.TenCheDoAs)
                .HasMaxLength(150)
                .HasColumnName("TenCheDoAS");
        });
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSp, e.MaHoaDon });

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaChiTietSp).HasColumnName("MaChiTietSP");
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GhiChu).HasMaxLength(4000);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_ChiTietSP");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
        });

        modelBuilder.Entity<ChiTietSp>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp);

            entity.ToTable("ChiTietSP");

            entity.Property(e => e.MaChiTietSp).HasColumnName("MaChiTietSP");
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhAnh).HasMaxLength(500);
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietSps)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK_ChiTietSP_DanhMucSP");
        });

        modelBuilder.Entity<ChucNangSp>(entity =>
        {
            entity.HasKey(e => e.MaChucNang);

            entity.ToTable("ChucNangSP");

            entity.Property(e => e.TenChucNang).HasMaxLength(150);
        });

        modelBuilder.Entity<DanhMucSp>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("DanhMucSP");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(500);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaCheDoAs).HasColumnName("MaCheDoAS");
            entity.Property(e => e.MoTa).HasMaxLength(4000);
            entity.Property(e => e.TenSp)
                .HasMaxLength(200)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaCheDoAsNavigation).WithMany(p => p.DanhMucSps)
                .HasForeignKey(d => d.MaCheDoAs)
                .HasConstraintName("FK_DanhMucSP_CheDoAS");

            entity.HasOne(d => d.MaChucNangNavigation).WithMany(p => p.DanhMucSps)
                .HasForeignKey(d => d.MaChucNang)
                .HasConstraintName("FK_DanhMucSP_ChucNangSP");

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.DanhMucSps)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK_DanhMucSP_KichThuocSP");
              
            entity.HasOne(d => d.MaMoiTruongSongNavigation).WithMany(p => p.DanhMucSps)
                .HasForeignKey(d => d.MaMoiTruongSong)
                .HasConstraintName("FK_DanhMucSP_MoiTruongSongSP");

            entity.HasOne(d => d.MaViTriNavigation).WithMany(p => p.DanhMucSps)
                .HasForeignKey(d => d.MaViTri)
                .HasConstraintName("FK_DanhMucSP_ViTri");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("HoaDon");

            entity.Property(e => e.GhiChu).HasMaxLength(4000);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_HoaDon_KhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_HoaDon_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang);

            entity.ToTable("KhachHang");

            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.SoDt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenKhachHang).HasMaxLength(150);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_KhachHang_User");
        });

        modelBuilder.Entity<KichThuocSp>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc);

            entity.ToTable("KichThuocSP");

            entity.Property(e => e.TenKichThuoc).HasMaxLength(150);
        });

        modelBuilder.Entity<MoiTruongSongSp>(entity =>
        {
            entity.HasKey(e => e.MaMoiTruongSong);

            entity.ToTable("MoiTruongSongSP");

            entity.Property(e => e.TenMoiTruongSong).HasMaxLength(150);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.SoDt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(150);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_NhanVien_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("User");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassWord)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViTri>(entity =>
        {
            entity.HasKey(e => e.MaViTri);

            entity.ToTable("ViTri");

            entity.Property(e => e.TenViTri).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
