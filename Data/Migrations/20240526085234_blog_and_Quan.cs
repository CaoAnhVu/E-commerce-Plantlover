using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_Plantlover.Migrations
{
    /// <inheritdoc />
    public partial class blog_and_Quan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "District",
                table: "OrderHeaders",
                newName: "Quan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quan",
                table: "OrderHeaders",
                newName: "District");
        }
    }
}
