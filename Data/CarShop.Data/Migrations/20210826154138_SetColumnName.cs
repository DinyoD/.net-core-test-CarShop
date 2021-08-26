using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShop.Data.Migrations
{
    public partial class SetColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlateNUmber",
                table: "Cars",
                newName: "PlateNumber");

            migrationBuilder.RenameColumn(
                name: "PictureUr",
                table: "Cars",
                newName: "PictureUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlateNumber",
                table: "Cars",
                newName: "PlateNUmber");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Cars",
                newName: "PictureUr");
        }
    }
}
