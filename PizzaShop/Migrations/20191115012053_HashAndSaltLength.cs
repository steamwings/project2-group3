using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaShop.Migrations
{
    public partial class HashAndSaltLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Customers",
                type: "char(24)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(16)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Customers",
                type: "char(44)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(32)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Customers",
                type: "char(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(24)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Customers",
                type: "char(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(44)");
        }
    }
}
