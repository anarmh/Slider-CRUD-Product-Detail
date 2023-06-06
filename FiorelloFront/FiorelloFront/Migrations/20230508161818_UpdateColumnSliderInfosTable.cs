using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFront.Migrations
{
    public partial class UpdateColumnSliderInfosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "SliderInfos",
                newName: "SignImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SignImage",
                table: "SliderInfos",
                newName: "Image");
        }
    }
}
