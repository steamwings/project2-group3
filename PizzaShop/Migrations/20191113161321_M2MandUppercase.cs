using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaShop.Migrations
{
    public partial class M2MandUppercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderSides_OrderId",
                table: "OrderSides",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSides_SideId",
                table: "OrderSides",
                column: "SideId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_OrderId",
                table: "OrderPizzas",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizzas_Orders",
                table: "OrderPizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_Pizzas",
                table: "OrderPizzas",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSides_Orders",
                table: "OrderSides",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSides_Sides",
                table: "OrderSides",
                column: "SideId",
                principalTable: "Sides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizzas_Orders",
                table: "OrderPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_Pizzas",
                table: "OrderPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSides_Orders",
                table: "OrderSides");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSides_Sides",
                table: "OrderSides");

            migrationBuilder.DropIndex(
                name: "IX_OrderSides_OrderId",
                table: "OrderSides");

            migrationBuilder.DropIndex(
                name: "IX_OrderSides_SideId",
                table: "OrderSides");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizzas_OrderId",
                table: "OrderPizzas");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas");
        }
    }
}
