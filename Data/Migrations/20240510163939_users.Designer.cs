﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cs_Plantlover.Migrations
{
    [DbContext(typeof(DoAnWebDbContext))]
    [Migration("20240510163939_users")]
    partial class users
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cs_Plantlover.Models.AnhSP", b =>
                {
                    b.Property<int>("MaAnhSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaAnhSP"));

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<string>("TenFileAnh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short?>("Vitri")
                        .HasColumnType("smallint");

                    b.HasKey("MaAnhSP");

                    b.HasIndex("MaSP");

                    b.ToTable("AnhSP");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.CheDoAS", b =>
                {
                    b.Property<int>("MaCheDoAS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCheDoAS"));

                    b.Property<string>("TenCheDoAS")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaCheDoAS");

                    b.ToTable("CheDoAs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("MaChiTietSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietSP"));

                    b.Property<decimal>("DonGiaBan")
                        .HasColumnType("decimal(17,2)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("MaChiTietSpNavigationMaChiTietSP")
                        .HasColumnType("int");

                    b.Property<int>("MaHoaDon")
                        .HasColumnType("int");

                    b.Property<int>("MaHoaDonNavigationMaHoaDon")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongBan")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietSP");

                    b.HasIndex("MaChiTietSpNavigationMaChiTietSP");

                    b.HasIndex("MaHoaDonNavigationMaHoaDon");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChiTietSP", b =>
                {
                    b.Property<int>("MaChiTietSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietSP"));

                    b.Property<decimal>("DonGiaBan")
                        .HasColumnType("decimal(17,2)");

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal(17,2)");

                    b.Property<decimal?>("GiamGia")
                        .HasColumnType("decimal(17,2)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int?>("MaSpNavigationMaSP")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietSP");

                    b.HasIndex("MaSpNavigationMaSP");

                    b.ToTable("ChiTietSps");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChucNangSP", b =>
                {
                    b.Property<int>("MaChucNang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChucNang"));

                    b.Property<string>("TenChucNang")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaChucNang");

                    b.ToTable("ChiTietSP");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.DanhMucSP", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSP"));

                    b.Property<string>("AnhDaiDien")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal(17,2)");

                    b.Property<int>("MaCheDoAS")
                        .HasColumnType("int");

                    b.Property<int?>("MaCheDoAsNavigationMaCheDoAS")
                        .HasColumnType("int");

                    b.Property<int>("MaChucNang")
                        .HasColumnType("int");

                    b.Property<int?>("MaChucNangNavigationMaChucNang")
                        .HasColumnType("int");

                    b.Property<int>("MaKichThuoc")
                        .HasColumnType("int");

                    b.Property<int?>("MaKichThuocNavigationMaKichThuoc")
                        .HasColumnType("int");

                    b.Property<int>("MaMoiTruongSong")
                        .HasColumnType("int");

                    b.Property<int?>("MaMoiTruongSongNavigationMaMoiTruongSong")
                        .HasColumnType("int");

                    b.Property<int>("MaViTri")
                        .HasColumnType("int");

                    b.Property<int?>("MaViTriNavigationMaViTri")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MaSP");

                    b.HasIndex("MaCheDoAsNavigationMaCheDoAS");

                    b.HasIndex("MaChucNangNavigationMaChucNang");

                    b.HasIndex("MaKichThuocNavigationMaKichThuoc");

                    b.HasIndex("MaMoiTruongSongNavigationMaMoiTruongSong");

                    b.HasIndex("MaViTriNavigationMaViTri");

                    b.ToTable("DanhMucSps");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHoaDon"));

                    b.Property<string>("GhiChu")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaKhachHangNavigationMaKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhanVienNavigationMaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PhuongThucThanhToan")
                        .HasColumnType("bit");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(17,2)");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaKhachHangNavigationMaKhachHang");

                    b.HasIndex("MaNhanVienNavigationMaNhanVien");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("SoDT")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.KichThuocSP", b =>
                {
                    b.Property<int>("MaKichThuoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKichThuoc"));

                    b.Property<string>("TenKichThuoc")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaKichThuoc");

                    b.ToTable("KichThuocSps");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.LeaveMessenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Messenger")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.ToTable("LeaveMessengers");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.MoiTruongSongSP", b =>
                {
                    b.Property<int>("MaMoiTruongSong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaMoiTruongSong"));

                    b.Property<string>("TenMoiTruongSong")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaMoiTruongSong");

                    b.ToTable("MoiTruongSongSps");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhanVien"));

                    b.Property<string>("ChucVu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GhiChu")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("SoDt")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaNhanVien");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MaSP");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderTotal")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Village")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Village")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ViTri", b =>
                {
                    b.Property<int>("MaViTri")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaViTri"));

                    b.Property<string>("TenViTri")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("MaViTri");

                    b.ToTable("ViTris");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Cs_Plantlover.Models.AnhSP", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.DanhMucSP", "DanhMucSP")
                        .WithMany("AnhSPs")
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucSP");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.ChiTietSP", "MaChiTietSpNavigation")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("MaChiTietSpNavigationMaChiTietSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cs_Plantlover.Models.HoaDon", "MaHoaDonNavigation")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("MaHoaDonNavigationMaHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaChiTietSpNavigation");

                    b.Navigation("MaHoaDonNavigation");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChiTietSP", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.DanhMucSP", "MaSpNavigation")
                        .WithMany("ChiTietSPs")
                        .HasForeignKey("MaSpNavigationMaSP");

                    b.Navigation("MaSpNavigation");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.DanhMucSP", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.CheDoAS", "MaCheDoAsNavigation")
                        .WithMany("DanhMucSPs")
                        .HasForeignKey("MaCheDoAsNavigationMaCheDoAS");

                    b.HasOne("Cs_Plantlover.Models.ChucNangSP", "MaChucNangNavigation")
                        .WithMany("DanhMucSPs")
                        .HasForeignKey("MaChucNangNavigationMaChucNang");

                    b.HasOne("Cs_Plantlover.Models.KichThuocSP", "MaKichThuocNavigation")
                        .WithMany("DanhMucSPs")
                        .HasForeignKey("MaKichThuocNavigationMaKichThuoc");

                    b.HasOne("Cs_Plantlover.Models.MoiTruongSongSP", "MaMoiTruongSongNavigation")
                        .WithMany("DanhMucSPs")
                        .HasForeignKey("MaMoiTruongSongNavigationMaMoiTruongSong");

                    b.HasOne("Cs_Plantlover.Models.ViTri", "MaViTriNavigation")
                        .WithMany("DanhMucSPs")
                        .HasForeignKey("MaViTriNavigationMaViTri");

                    b.Navigation("MaCheDoAsNavigation");

                    b.Navigation("MaChucNangNavigation");

                    b.Navigation("MaKichThuocNavigation");

                    b.Navigation("MaMoiTruongSongNavigation");

                    b.Navigation("MaViTriNavigation");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.HoaDon", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.KhachHang", "MaKhachHangNavigation")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaKhachHangNavigationMaKhachHang");

                    b.HasOne("Cs_Plantlover.Models.NhanVien", "MaNhanVienNavigation")
                        .WithMany("HoaDons")
                        .HasForeignKey("MaNhanVienNavigationMaNhanVien");

                    b.Navigation("MaKhachHangNavigation");

                    b.Navigation("MaNhanVienNavigation");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.OrderDetails", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.DanhMucSP", "DanhMucSP")
                        .WithMany()
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cs_Plantlover.Models.OrderHeader", "OrderHeader")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucSP");

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.OrderHeader", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cs_Plantlover.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Cs_Plantlover.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cs_Plantlover.Models.CheDoAS", b =>
                {
                    b.Navigation("DanhMucSPs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChiTietSP", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ChucNangSP", b =>
                {
                    b.Navigation("DanhMucSPs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.DanhMucSP", b =>
                {
                    b.Navigation("AnhSPs");

                    b.Navigation("ChiTietSPs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.KichThuocSP", b =>
                {
                    b.Navigation("DanhMucSPs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.MoiTruongSongSP", b =>
                {
                    b.Navigation("DanhMucSPs");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.NhanVien", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Cs_Plantlover.Models.ViTri", b =>
                {
                    b.Navigation("DanhMucSPs");
                });
#pragma warning restore 612, 618
        }
    }
}
