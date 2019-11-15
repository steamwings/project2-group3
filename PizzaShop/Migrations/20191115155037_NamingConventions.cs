using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaShop.Migrations
{
    public partial class NamingConventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Recipes_Pizzas",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_PizzaId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_OrderSides_OrderId",
                table: "OrderSides");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizzas_OrderId",
                table: "OrderPizzas");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderSides");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderPizzas");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "OrderPizzas");

            migrationBuilder.AddColumn<int>(
                name: "NPizzaId",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NOrderId",
                table: "OrderSides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NOrderId",
                table: "OrderPizzas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NPizzaId",
                table: "OrderPizzas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOrders_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NPizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustTypeId = table.Column<int>(nullable: false),
                    CheeseTypeId = table.Column<int>(nullable: false),
                    SauceTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_CheeseTypes",
                        column: x => x.CheeseTypeId,
                        principalTable: "CheeseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_CrustTypes",
                        column: x => x.CrustTypeId,
                        principalTable: "CrustTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_SauceTypes",
                        column: x => x.SauceTypeId,
                        principalTable: "SauceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NPizzaId",
                table: "Recipes",
                column: "NPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSides_NOrderId",
                table: "OrderSides",
                column: "NOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_NOrderId",
                table: "OrderPizzas",
                column: "NOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_NPizzaId",
                table: "OrderPizzas",
                column: "NPizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_NOrders_CustomerId",
                table: "NOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_NPizzas_CheeseTypeId",
                table: "NPizzas",
                column: "CheeseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NPizzas_CrustTypeId",
                table: "NPizzas",
                column: "CrustTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NPizzas_SauceTypeId",
                table: "NPizzas",
                column: "SauceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizzas_NOrders",
                table: "OrderPizzas",
                column: "NOrderId",
                principalTable: "NOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_NPizzas",
                table: "OrderPizzas",
                column: "NPizzaId",
                principalTable: "NPizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSides_NOrders",
                table: "OrderSides",
                column: "NOrderId",
                principalTable: "NOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_NPizzas",
                table: "Recipes",
                column: "NPizzaId",
                principalTable: "NPizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizzas_NOrders",
                table: "OrderPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_NPizzas",
                table: "OrderPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSides_NOrders",
                table: "OrderSides");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_NPizzas",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "NOrders");

            migrationBuilder.DropTable(
                name: "NPizzas");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_NPizzaId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_OrderSides_NOrderId",
                table: "OrderSides");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizzas_NOrderId",
                table: "OrderPizzas");

            migrationBuilder.DropIndex(
                name: "IX_OrderPizzas_NPizzaId",
                table: "OrderPizzas");

            migrationBuilder.DropColumn(
                name: "NPizzaId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "NOrderId",
                table: "OrderSides");

            migrationBuilder.DropColumn(
                name: "NOrderId",
                table: "OrderPizzas");

            migrationBuilder.DropColumn(
                name: "NPizzaId",
                table: "OrderPizzas");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderSides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderPizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "OrderPizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheeseTypeId = table.Column<int>(type: "int", nullable: false),
                    CrustTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SauceTypeId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_CheeseTypes",
                        column: x => x.CheeseTypeId,
                        principalTable: "CheeseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_CrustTypes",
                        column: x => x.CrustTypeId,
                        principalTable: "CrustTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_SauceTypes",
                        column: x => x.SauceTypeId,
                        principalTable: "SauceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PizzaId",
                table: "Recipes",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSides_OrderId",
                table: "OrderSides",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_OrderId",
                table: "OrderPizzas",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CheeseTypeId",
                table: "Pizzas",
                column: "CheeseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustTypeId",
                table: "Pizzas",
                column: "CrustTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceTypeId",
                table: "Pizzas",
                column: "SauceTypeId");

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
                name: "FK_Recipes_Pizzas",
                table: "Recipes",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
