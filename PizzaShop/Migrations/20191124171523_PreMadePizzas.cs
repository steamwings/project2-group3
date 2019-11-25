using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaShop.Migrations
{
    public partial class PreMadePizzas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreMadePizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    PriceCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMadePizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreMadePizzas_PriceCategory",
                        column: x => x.PriceCategoryId,
                        principalTable: "PriceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPreMadePizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOrderId = table.Column<int>(nullable: false),
                    PreMadePizzaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPreMadePizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPreMadePizzas_NOrders",
                        column: x => x.NOrderId,
                        principalTable: "NOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPreMadePizzas_PreMadePizzas",
                        column: x => x.PreMadePizzaId,
                        principalTable: "PreMadePizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPreMadePizzas_NOrderId",
                table: "OrderPreMadePizzas",
                column: "NOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPreMadePizzas_PreMadePizzaId",
                table: "OrderPreMadePizzas",
                column: "PreMadePizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreMadePizzas_PriceCategoryId",
                table: "PreMadePizzas",
                column: "PriceCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPreMadePizzas");

            migrationBuilder.DropTable(
                name: "PreMadePizzas");
        }
    }
}
