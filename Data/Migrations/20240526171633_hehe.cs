using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Plantlover.Migrations
{
    /// <inheritdoc />
    public partial class hehe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "BlogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChucNangSPMaChucNang = table.Column<int>(type: "int", nullable: false),
                    ViTriMaViTri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogDetails_ChiTietSP_ChucNangSPMaChucNang",
                        column: x => x.ChucNangSPMaChucNang,
                        principalTable: "ChiTietSP",
                        principalColumn: "MaChucNang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogDetails_ViTris_ViTriMaViTri",
                        column: x => x.ViTriMaViTri,
                        principalTable: "ViTris",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_ChucNangSPMaChucNang",
                table: "BlogDetails",
                column: "ChucNangSPMaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_UserId",
                table: "BlogDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_ViTriMaViTri",
                table: "BlogDetails",
                column: "ViTriMaViTri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogDetails");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChucNangSPMaChucNang = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ViTriMaViTri = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blogs_ChiTietSP_ChucNangSPMaChucNang",
                        column: x => x.ChucNangSPMaChucNang,
                        principalTable: "ChiTietSP",
                        principalColumn: "MaChucNang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_ViTris_ViTriMaViTri",
                        column: x => x.ViTriMaViTri,
                        principalTable: "ViTris",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ChucNangSPMaChucNang",
                table: "Blogs",
                column: "ChucNangSPMaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ViTriMaViTri",
                table: "Blogs",
                column: "ViTriMaViTri");
        }
    }
}
