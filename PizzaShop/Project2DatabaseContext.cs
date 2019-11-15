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
        public virtual DbSet<NOrders> NOrders { get; set; }
        public virtual DbSet<NPizzas> NPizzas { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings { get; set; }
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

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.HasAlternateKey(e => e.Email)
                    .HasName("AlternateKey_Email");
            });

            modelBuilder.Entity<NOrders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.NOrders)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NOrders_Customers");
            });

            modelBuilder.Entity<OrderPizzas>(entity =>
            {
                entity.HasOne(e => e.NOrder)
                    .WithMany(o => o.OrderPizzas)
                    .HasForeignKey(e => e.NOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderPizzas_NOrders");

                entity.HasOne(e => e.NPizza)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(e => e.NPizzaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderPizza_NPizzas");
            });

            modelBuilder.Entity<OrderSides>(entity =>
            {
                entity.HasOne(e => e.NOrder)
                    .WithMany(o => o.OrderSides)
                    .HasForeignKey(e => e.NOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderSides_NOrders");

                entity.HasOne(e => e.Side)
                    .WithMany(p => p.OrderSides)
                    .HasForeignKey(e => e.SideId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OrderSides_Sides");
            });

            modelBuilder.Entity<NPizzas>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.CheeseType)
                    .WithMany(p => p.NPizzas)
                    .HasForeignKey(d => d.CheeseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_CheeseTypes");

                entity.HasOne(d => d.CrustType)
                    .WithMany(p => p.NPizzas)
                    .HasForeignKey(d => d.CrustTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_CrustTypes");

                entity.HasOne(d => d.SauceType)
                    .WithMany(p => p.NPizzas)
                    .HasForeignKey(d => d.SauceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_SauceTypes");
            });

            modelBuilder.Entity<PizzaToppings>(entity =>
            {
                entity.HasOne(d => d.NPizza)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.NPizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipes_NPizzas");

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
