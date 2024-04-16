using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsPlantlover.Migrations
{
    /// <inheritdoc />
    public partial class addDbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheDoAs",
                columns: table => new
                {
                    MaCheDoAS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCheDoAS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheDoAs", x => x.MaCheDoAS);
                });

            migrationBuilder.CreateTable(
                name: "ChucNangSps",
                columns: table => new
                {
                    MaChucNang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucNang = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNangSps", x => x.MaChucNang);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKhachHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    SoDT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "KichThuocSps",
                columns: table => new
                {
                    MaKichThuoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKichThuoc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichThuocSps", x => x.MaKichThuoc);
                });

            migrationBuilder.CreateTable(
                name: "MoiTruongSongSps",
                columns: table => new
                {
                    MaMoiTruongSong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMoiTruongSong = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoiTruongSongSps", x => x.MaMoiTruongSong);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    SoDt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "ViTris",
                columns: table => new
                {
                    MaViTri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenViTri = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTris", x => x.MaViTri);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaKhachHang = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    MaKhachHangNavigationMaKhachHang = table.Column<int>(type: "int", nullable: true),
                    MaNhanVienNavigationMaNhanVien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_MaKhachHangNavigationMaKhachHang",
                        column: x => x.MaKhachHangNavigationMaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang");
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_MaNhanVienNavigationMaNhanVien",
                        column: x => x.MaNhanVienNavigationMaNhanVien,
                        principalTable: "NhanViens",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "DanhMucSps",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaChucNang = table.Column<int>(type: "int", nullable: false),
                    MaViTri = table.Column<int>(type: "int", nullable: false),
                    MaCheDoAS = table.Column<int>(type: "int", nullable: false),
                    MaKichThuoc = table.Column<int>(type: "int", nullable: false),
                    MaMoiTruongSong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    MaCheDoAsNavigationMaCheDoAS = table.Column<int>(type: "int", nullable: true),
                    MaChucNangNavigationMaChucNang = table.Column<int>(type: "int", nullable: true),
                    MaKichThuocNavigationMaKichThuoc = table.Column<int>(type: "int", nullable: true),
                    MaMoiTruongSongNavigationMaMoiTruongSong = table.Column<int>(type: "int", nullable: true),
                    MaViTriNavigationMaViTri = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucSps", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_DanhMucSps_CheDoAs_MaCheDoAsNavigationMaCheDoAS",
                        column: x => x.MaCheDoAsNavigationMaCheDoAS,
                        principalTable: "CheDoAs",
                        principalColumn: "MaCheDoAS");
                    table.ForeignKey(
                        name: "FK_DanhMucSps_ChucNangSps_MaChucNangNavigationMaChucNang",
                        column: x => x.MaChucNangNavigationMaChucNang,
                        principalTable: "ChucNangSps",
                        principalColumn: "MaChucNang");
                    table.ForeignKey(
                        name: "FK_DanhMucSps_KichThuocSps_MaKichThuocNavigationMaKichThuoc",
                        column: x => x.MaKichThuocNavigationMaKichThuoc,
                        principalTable: "KichThuocSps",
                        principalColumn: "MaKichThuoc");
                    table.ForeignKey(
                        name: "FK_DanhMucSps_MoiTruongSongSps_MaMoiTruongSongNavigationMaMoiTruongSong",
                        column: x => x.MaMoiTruongSongNavigationMaMoiTruongSong,
                        principalTable: "MoiTruongSongSps",
                        principalColumn: "MaMoiTruongSong");
                    table.ForeignKey(
                        name: "FK_DanhMucSps_ViTris_MaViTriNavigationMaViTri",
                        column: x => x.MaViTriNavigationMaViTri,
                        principalTable: "ViTris",
                        principalColumn: "MaViTri");
                });

            migrationBuilder.CreateTable(
                name: "AnhSP",
                columns: table => new
                {
                    MaAnhSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    TenFileAnh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vitri = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhSP", x => x.MaAnhSP);
                    table.ForeignKey(
                        name: "FK_AnhSP_DanhMucSps_MaSP",
                        column: x => x.MaSP,
                        principalTable: "DanhMucSps",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSps",
                columns: table => new
                {
                    MaChiTietSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DonGiaBan = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    GiamGia = table.Column<decimal>(type: "decimal(17,2)", nullable: true),
                    GiaBan = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MaSpNavigationMaSP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSps", x => x.MaChiTietSP);
                    table.ForeignKey(
                        name: "FK_ChiTietSps_DanhMucSps_MaSpNavigationMaSP",
                        column: x => x.MaSpNavigationMaSP,
                        principalTable: "DanhMucSps",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "AnhChiTietSP",
                columns: table => new
                {
                    MaChiTietSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenFileAnh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vitri = table.Column<short>(type: "smallint", nullable: false),
                    ChiTietSPMaChiTietSP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhChiTietSP", x => x.MaChiTietSP);
                    table.ForeignKey(
                        name: "FK_AnhChiTietSP_ChiTietSps_ChiTietSPMaChiTietSP",
                        column: x => x.ChiTietSPMaChiTietSP,
                        principalTable: "ChiTietSps",
                        principalColumn: "MaChiTietSP");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaChiTietSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<int>(type: "int", nullable: false),
                    SoLuongBan = table.Column<int>(type: "int", nullable: false),
                    DonGiaBan = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    MaChiTietSpNavigationMaChiTietSP = table.Column<int>(type: "int", nullable: false),
                    MaHoaDonNavigationMaHoaDon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.MaChiTietSP);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_ChiTietSps_MaChiTietSpNavigationMaChiTietSP",
                        column: x => x.MaChiTietSpNavigationMaChiTietSP,
                        principalTable: "ChiTietSps",
                        principalColumn: "MaChiTietSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHoaDonNavigationMaHoaDon",
                        column: x => x.MaHoaDonNavigationMaHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhChiTietSP_ChiTietSPMaChiTietSP",
                table: "AnhChiTietSP",
                column: "ChiTietSPMaChiTietSP");

            migrationBuilder.CreateIndex(
                name: "IX_AnhSP_MaSP",
                table: "AnhSP",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaChiTietSpNavigationMaChiTietSP",
                table: "ChiTietHoaDons",
                column: "MaChiTietSpNavigationMaChiTietSP");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaHoaDonNavigationMaHoaDon",
                table: "ChiTietHoaDons",
                column: "MaHoaDonNavigationMaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSps_MaSpNavigationMaSP",
                table: "ChiTietSps",
                column: "MaSpNavigationMaSP");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucSps_MaCheDoAsNavigationMaCheDoAS",
                table: "DanhMucSps",
                column: "MaCheDoAsNavigationMaCheDoAS");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucSps_MaChucNangNavigationMaChucNang",
                table: "DanhMucSps",
                column: "MaChucNangNavigationMaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucSps_MaKichThuocNavigationMaKichThuoc",
                table: "DanhMucSps",
                column: "MaKichThuocNavigationMaKichThuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucSps_MaMoiTruongSongNavigationMaMoiTruongSong",
                table: "DanhMucSps",
                column: "MaMoiTruongSongNavigationMaMoiTruongSong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucSps_MaViTriNavigationMaViTri",
                table: "DanhMucSps",
                column: "MaViTriNavigationMaViTri");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaKhachHangNavigationMaKhachHang",
                table: "HoaDons",
                column: "MaKhachHangNavigationMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaNhanVienNavigationMaNhanVien",
                table: "HoaDons",
                column: "MaNhanVienNavigationMaNhanVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhChiTietSP");

            migrationBuilder.DropTable(
                name: "AnhSP");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "ChiTietSps");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "DanhMucSps");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "CheDoAs");

            migrationBuilder.DropTable(
                name: "ChucNangSps");

            migrationBuilder.DropTable(
                name: "KichThuocSps");

            migrationBuilder.DropTable(
                name: "MoiTruongSongSps");

            migrationBuilder.DropTable(
                name: "ViTris");
        }
    }
}
