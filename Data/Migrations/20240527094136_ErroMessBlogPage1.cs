using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Plantlover.Migrations
{
    /// <inheritdoc />
    public partial class ErroMessBlogPage1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ChiTietSP_MaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ViTris_MaViTri",
                table: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_BlogDetails_MaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_BlogDetails_MaViTri",
                table: "BlogDetails");

            migrationBuilder.AddColumn<int>(
                name: "ChucNangSPMaChucNang",
                table: "BlogDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViTriMaViTri",
                table: "BlogDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_ChucNangSPMaChucNang",
                table: "BlogDetails",
                column: "ChucNangSPMaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_ViTriMaViTri",
                table: "BlogDetails",
                column: "ViTriMaViTri");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_ChiTietSP_ChucNangSPMaChucNang",
                table: "BlogDetails",
                column: "ChucNangSPMaChucNang",
                principalTable: "ChiTietSP",
                principalColumn: "MaChucNang");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_ViTris_ViTriMaViTri",
                table: "BlogDetails",
                column: "ViTriMaViTri",
                principalTable: "ViTris",
                principalColumn: "MaViTri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ChiTietSP_ChucNangSPMaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ViTris_ViTriMaViTri",
                table: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_BlogDetails_ChucNangSPMaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropIndex(
                name: "IX_BlogDetails_ViTriMaViTri",
                table: "BlogDetails");

            migrationBuilder.DropColumn(
                name: "ChucNangSPMaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropColumn(
                name: "ViTriMaViTri",
                table: "BlogDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_MaChucNang",
                table: "BlogDetails",
                column: "MaChucNang");

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_MaViTri",
                table: "BlogDetails",
                column: "MaViTri");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_ChiTietSP_MaChucNang",
                table: "BlogDetails",
                column: "MaChucNang",
                principalTable: "ChiTietSP",
                principalColumn: "MaChucNang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_ViTris_MaViTri",
                table: "BlogDetails",
                column: "MaViTri",
                principalTable: "ViTris",
                principalColumn: "MaViTri",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
