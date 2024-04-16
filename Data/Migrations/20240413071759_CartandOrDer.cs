using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Plantlover.Migrations
{
    /// <inheritdoc />
    public partial class CartandOrDer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucSps_ChucNangSps_MaChucNangNavigationMaChucNang",
                table: "DanhMucSps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChucNangSps",
                table: "ChucNangSps");

            migrationBuilder.RenameTable(
                name: "ChucNangSps",
                newName: "ChiTietSP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietSP",
                table: "ChiTietSP",
                column: "MaChucNang");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_DanhMucSps_MaSP",
                        column: x => x.MaSP,
                        principalTable: "DanhMucSps",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MaSP",
                table: "Carts",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucSps_ChiTietSP_MaChucNangNavigationMaChucNang",
                table: "DanhMucSps",
                column: "MaChucNangNavigationMaChucNang",
                principalTable: "ChiTietSP",
                principalColumn: "MaChucNang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucSps_ChiTietSP_MaChucNangNavigationMaChucNang",
                table: "DanhMucSps");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietSP",
                table: "ChiTietSP");

            migrationBuilder.RenameTable(
                name: "ChiTietSP",
                newName: "ChucNangSps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChucNangSps",
                table: "ChucNangSps",
                column: "MaChucNang");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucSps_ChucNangSps_MaChucNangNavigationMaChucNang",
                table: "DanhMucSps",
                column: "MaChucNangNavigationMaChucNang",
                principalTable: "ChucNangSps",
                principalColumn: "MaChucNang");
        }
    }
}
