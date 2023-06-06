using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFront.Migrations
{
    public partial class CreateColumnIsMainProductImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
