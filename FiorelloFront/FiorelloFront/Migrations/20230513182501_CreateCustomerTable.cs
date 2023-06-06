using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloFront.Migrations
{
    public partial class CreateCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "FullName", "SoftDelete" },
                values: new object[] { 1, 36, "Anar Huseynov", false });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "FullName", "SoftDelete" },
                values: new object[] { 2, 36, "Tunar Huseynli", false });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "FullName", "SoftDelete" },
                values: new object[] { 3, 36, "Elnar Huseynli", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
