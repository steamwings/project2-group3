using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaShop.Migrations
{
    public partial class CustomerEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Email",
                table: "Customers",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");
        }
    }
}
