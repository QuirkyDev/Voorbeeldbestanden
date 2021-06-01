using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadImages.Migrations
{
    public partial class ChangeBestandToBestandsnaam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afbeelding",
                schema: "UploadImages",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Bestandsnaam",
                schema: "UploadImages",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bestandsnaam",
                schema: "UploadImages",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Afbeelding",
                schema: "UploadImages",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
