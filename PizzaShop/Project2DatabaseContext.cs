using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PizzaData.Models;

namespace PizzaShop
{
    public partial class Project2DatabaseContext : DbContext
    {
        public Project2DatabaseContext()
        {
        }

        public Project2DatabaseContext(DbContextOptions<Project2DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CheeseTypes> CheeseTypes { get; set; }
        public virtual DbSet<CrustTypes> CrustTypes { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderPizzas> OrderPizzas { get; set; }
        public virtual DbSet<OrderSides> OrderSides { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<SauceTypes> SauceTypes { get; set; }
        public virtual DbSet<Sides> Sides { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("DbContext not configured.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseTypes>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CrustTypes>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrderTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderPizzas>(entity =>
            {
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderPizzas)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderPizzas_Orders");

                entity.HasOne(e => e.Pizza)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(e => e.PizzaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderPizza_Pizzas");
            });

            modelBuilder.Entity<OrderSides>(entity =>
            {
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderSides)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderSides_Orders");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.OrderSides)
                    .HasForeignKey(e => e.SideId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderSides_Sides");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CheeseType)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CheeseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_CheeseTypes");

                entity.HasOne(d => d.CrustType)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CrustTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_CrustTypes");

                entity.HasOne(d => d.SauceType)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.SauceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_SauceTypes");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipes_Pizzas");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipes_Toppings");
            });

            modelBuilder.Entity<SauceTypes>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sides>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
