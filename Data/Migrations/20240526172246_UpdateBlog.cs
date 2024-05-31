using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Plantlover.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ChiTietSP_ChucNangSPMaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ViTris_ViTriMaViTri",
                table: "BlogDetails");

            migrationBuilder.RenameColumn(
                name: "ViTriMaViTri",
                table: "BlogDetails",
                newName: "MaViTri");

            migrationBuilder.RenameColumn(
                name: "ChucNangSPMaChucNang",
                table: "BlogDetails",
                newName: "MaChucNang");

            migrationBuilder.RenameIndex(
                name: "IX_BlogDetails_ViTriMaViTri",
                table: "BlogDetails",
                newName: "IX_BlogDetails_MaViTri");

            migrationBuilder.RenameIndex(
                name: "IX_BlogDetails_ChucNangSPMaChucNang",
                table: "BlogDetails",
                newName: "IX_BlogDetails_MaChucNang");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ChiTietSP_MaChucNang",
                table: "BlogDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogDetails_ViTris_MaViTri",
                table: "BlogDetails");

            migrationBuilder.RenameColumn(
                name: "MaViTri",
                table: "BlogDetails",
                newName: "ViTriMaViTri");

            migrationBuilder.RenameColumn(
                name: "MaChucNang",
                table: "BlogDetails",
                newName: "ChucNangSPMaChucNang");

            migrationBuilder.RenameIndex(
                name: "IX_BlogDetails_MaViTri",
                table: "BlogDetails",
                newName: "IX_BlogDetails_ViTriMaViTri");

            migrationBuilder.RenameIndex(
                name: "IX_BlogDetails_MaChucNang",
                table: "BlogDetails",
                newName: "IX_BlogDetails_ChucNangSPMaChucNang");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_ChiTietSP_ChucNangSPMaChucNang",
                table: "BlogDetails",
                column: "ChucNangSPMaChucNang",
                principalTable: "ChiTietSP",
                principalColumn: "MaChucNang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogDetails_ViTris_ViTriMaViTri",
                table: "BlogDetails",
                column: "ViTriMaViTri",
                principalTable: "ViTris",
                principalColumn: "MaViTri",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
