﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaShop;

namespace PizzaShop.Migrations
{
    [DbContext(typeof(Project2DatabaseContext))]
    [Migration("20191115002713_CustomerEmail")]
    partial class CustomerEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaData.Models.CheeseTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CheeseTypes");
                });

            modelBuilder.Entity("PizzaData.Models.CrustTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CrustTypes");
                });

            modelBuilder.Entity("PizzaData.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("char(32)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("char(16)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email")
                        .HasName("AlternateKey_Email");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaData.Models.OrderPizzas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderPizzas");
                });

            modelBuilder.Entity("PizzaData.Models.OrderSides", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("SideId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SideId");

                    b.ToTable("OrderSides");
                });

            modelBuilder.Entity("PizzaData.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaData.Models.Pizzas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CheeseTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CrustTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SauceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheeseTypeId");

                    b.HasIndex("CrustTypeId");

                    b.HasIndex("SauceTypeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaData.Models.Recipes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("ToppingId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("PizzaData.Models.SauceTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SauceTypes");
                });

            modelBuilder.Entity("PizzaData.Models.Sides", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Sides");
                });

            modelBuilder.Entity("PizzaData.Models.Toppings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaData.Models.OrderPizzas", b =>
                {
                    b.HasOne("PizzaData.Models.Orders", "Order")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderPizzas_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaData.Models.Pizzas", "Pizza")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("FK_OrderPizza_Pizzas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaData.Models.OrderSides", b =>
                {
                    b.HasOne("PizzaData.Models.Orders", "Order")
                        .WithMany("OrderSides")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderSides_Orders")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaData.Models.Sides", "Side")
                        .WithMany("OrderSides")
                        .HasForeignKey("SideId")
                        .HasConstraintName("FK_OrderSides_Sides")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaData.Models.Orders", b =>
                {
                    b.HasOne("PizzaData.Models.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaData.Models.Pizzas", b =>
                {
                    b.HasOne("PizzaData.Models.CheeseTypes", "CheeseType")
                        .WithMany("Pizzas")
                        .HasForeignKey("CheeseTypeId")
                        .HasConstraintName("FK_Pizzas_CheeseTypes")
                        .IsRequired();

                    b.HasOne("PizzaData.Models.CrustTypes", "CrustType")
                        .WithMany("Pizzas")
                        .HasForeignKey("CrustTypeId")
                        .HasConstraintName("FK_Pizzas_CrustTypes")
                        .IsRequired();

                    b.HasOne("PizzaData.Models.SauceTypes", "SauceType")
                        .WithMany("Pizzas")
                        .HasForeignKey("SauceTypeId")
                        .HasConstraintName("FK_Pizzas_SauceTypes")
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaData.Models.Recipes", b =>
                {
                    b.HasOne("PizzaData.Models.Pizzas", "Pizza")
                        .WithMany("Recipes")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("FK_Recipes_Pizzas")
                        .IsRequired();

                    b.HasOne("PizzaData.Models.Toppings", "Topping")
                        .WithMany("Recipes")
                        .HasForeignKey("ToppingId")
                        .HasConstraintName("FK_Recipes_Toppings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
