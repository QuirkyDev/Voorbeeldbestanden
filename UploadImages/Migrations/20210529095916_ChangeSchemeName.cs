using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadImages.Migrations
{
    public partial class ChangeSchemeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UploadImages");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "UploadImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Product",
                schema: "UploadImages",
                newName: "Product");
        }
    }
}
