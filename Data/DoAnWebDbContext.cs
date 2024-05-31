using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cs_Plantlover.Models;

namespace Data
{
    public class DoAnWebDbContext : IdentityDbContext<User>
    {
        public DoAnWebDbContext()
        {
        }

        public DoAnWebDbContext(DbContextOptions<DoAnWebDbContext> options) : base(options)
        {
        }

        public DbSet<CheDoAS> CheDoAs { get; set; }

        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public DbSet<ChiTietSP> ChiTietSps { get; set; }

        public DbSet<ChucNangSP> ChiTietSP { get; set; }

        public DbSet<DanhMucSP> DanhMucSps { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }

        public DbSet<KichThuocSP> KichThuocSps { get; set; }

        public DbSet<MoiTruongSongSP> MoiTruongSongSps { get; set; }

        public DbSet<NhanVien> NhanViens { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<ViTri> ViTris { get; set; }
        public DbSet<LeaveMessenger> LeaveMessengers { get; set; }
        
        /*public DbSet<Cart> Carts { get; set; }*/
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<Unit> Units { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucSP>()
                .HasMany(d => d.AnhSPs)
                .WithOne(a => a.DanhMucSP)
                .HasForeignKey(a => a.MaSP);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(c => c.DonGiaBan)
                .HasColumnType("decimal(17,2)");

            modelBuilder.Entity<ChiTietSP>()
                .Property(c => c.DonGiaBan)
                .HasColumnType("decimal(17,2)");

            modelBuilder.Entity<ChiTietSP>()
                .Property(c => c.GiaBan)
                .HasColumnType("decimal(17,2)");

            modelBuilder.Entity<ChiTietSP>()
                .Property(c => c.GiamGia)
                .HasColumnType("decimal(17,2)");

            modelBuilder.Entity<DanhMucSP>()
                .Property(c => c.GiaBan)
                .HasColumnType("decimal(17,2)");

            modelBuilder.Entity<HoaDon>()
                .Property(c => c.TongTien)
                .HasColumnType("decimal(17,2)");

          
            base.OnModelCreating(modelBuilder);
        }
    }
}
