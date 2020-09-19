using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=LaptopDatabase;User=sa;Pwd=Laptopsql1234;Trusted_Connection=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Brand
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(prop => prop.BrandName)
                    .HasColumnType("varchar(20)")
                    .IsRequired();
                entity.HasMany<Laptop>()
                    .WithOne(e => e.Brand)
                    .HasForeignKey(fk => fk.BrandId)
                    .HasConstraintName("FK_Brand_Laptop")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
            });
            #endregion
            #region Discount
            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(prop => prop.Code)
                    .HasColumnType("varchar(20)");
                entity.Property(prop => prop.ExpiredTime)
                    .HasColumnType("datetime");
                entity.Property(prop => prop.Amount)
                    .HasColumnType("decimal(10,2)");
                entity.HasMany<OrderDetail>()
                    .WithOne(e => e.Discount)
                    .HasForeignKey(fk => fk.DiscountId)
                    .HasConstraintName("FK_Discount_OrderDetail")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
            });
            #endregion
            #region Laptop
            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.Property(prop => prop.LaptopName)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.Quantity)
                    .HasColumnType("int");
                entity.Property(prop => prop.Price)
                    .HasColumnType("decimal(10,2)");
                entity.Property(prop => prop.SeriesCPU)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.DisplayScreen)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.GraphicCard)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.Storage)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.Pin)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.Weight)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.BrandId)
                    .HasColumnType("int");
                entity.HasMany<OrderDetail>()
                    .WithOne(e => e.Laptop)
                    .HasForeignKey(fk => fk.LaptopId)
                    .HasConstraintName("FK_Laptop_OrderDetail")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
                entity.HasOne<Brand>()
                    .WithMany(e => e.Laptops)
                    .HasForeignKey(fk => fk.BrandId)
                    .HasConstraintName("FK_Laptop_Brand")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);

            });
            #endregion
            #region Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(prop => prop.UserName)
                    .HasColumnType("varchar(20)");
                entity.Property(prop => prop.CreatedTime)
                    .HasColumnType("datetime");
                entity.Property(prop => prop.PaymentMethod)
                    .HasColumnType("varchar(50)");
                entity.Property(prop => prop.TotalPrice)
                    .HasColumnType("decimal(10,2)");
                entity.HasMany<OrderDetail>()
                    .WithOne(e => e.Order)
                    .HasForeignKey(fk => fk.OrderId)
                    .HasConstraintName("FK_Order_OrderDetail")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
            });
            #endregion
            #region OrderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(prop => prop.Quantity)
                    .HasColumnType("int");
                entity.Property(prop => prop.Price)
                    .HasColumnType("decimal(10,2)");
            });
            #endregion
            #region Picture
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(prop => prop.PictureUrl)
                    .HasColumnType("varchar(200)");
                entity.HasOne<Laptop>()
                    .WithMany(e => e.Pictures)
                    .HasForeignKey(fk => fk.LaptopId)
                    .HasConstraintName("FK_Picture_Laptop")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
            });
            #endregion
            #region Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(prop => prop.RoleName)
                    .HasColumnType("varchar(50)");
                entity.HasMany<User>()
                    .WithOne(e => e.Role)
                    .HasForeignKey(fk => fk.RoleId)
                    .HasConstraintName("FK_User_Role")
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
            });
            #endregion
            #region User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(key => key.UserName);
                entity.Property(prop => prop.UserName)
                    .HasColumnType("varchar(20)");
                entity.Property(prop => prop.FullName)
                    .HasColumnType("nvarchar(100)");
                entity.Property(prop => prop.Email)
                    .HasColumnType("varchar(100)");
            });
            #endregion
        }
        #region DbSet
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
