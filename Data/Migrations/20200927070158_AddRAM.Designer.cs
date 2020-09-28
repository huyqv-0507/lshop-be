﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(LaptopDbContext))]
    [Migration("20200927070158_AddRAM")]
    partial class AddRAM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Data.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Data.Models.Laptop", b =>
                {
                    b.Property<int>("LaptopId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId1");

                    b.Property<string>("DisplayScreen")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GraphicCard")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LaptopName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pin")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Ram");

                    b.Property<string>("SeriesCPU")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Storage")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(50)");

                    b.HasKey("LaptopId");

                    b.HasIndex("BrandId");

                    b.HasIndex("BrandId1");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserName");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountId");

                    b.Property<int?>("DiscountId1");

                    b.Property<int>("LaptopId");

                    b.Property<int?>("LaptopId1");

                    b.Property<int>("OrderId");

                    b.Property<int?>("OrderId1");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("DiscountId1");

                    b.HasIndex("LaptopId");

                    b.HasIndex("LaptopId1");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderId1");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Data.Models.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LaptopId");

                    b.Property<int?>("LaptopId1");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("varchar(200)");

                    b.HasKey("PictureId");

                    b.HasIndex("LaptopId");

                    b.HasIndex("LaptopId1");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Data.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("RoleId");

                    b.Property<int?>("RoleId1");

                    b.HasKey("UserName");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Models.Laptop", b =>
                {
                    b.HasOne("Data.Models.Brand")
                        .WithMany("Laptops")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_Laptop_Brand");

                    b.HasOne("Data.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId1");
                });

            modelBuilder.Entity("Data.Models.Order", b =>
                {
                    b.HasOne("Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserName");
                });

            modelBuilder.Entity("Data.Models.OrderDetail", b =>
                {
                    b.HasOne("Data.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .HasConstraintName("FK_Discount_OrderDetail");

                    b.HasOne("Data.Models.Discount")
                        .WithMany("OrderDetails")
                        .HasForeignKey("DiscountId1");

                    b.HasOne("Data.Models.Laptop", "Laptop")
                        .WithMany()
                        .HasForeignKey("LaptopId")
                        .HasConstraintName("FK_Laptop_OrderDetail");

                    b.HasOne("Data.Models.Laptop")
                        .WithMany("OrderDetails")
                        .HasForeignKey("LaptopId1");

                    b.HasOne("Data.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Order_OrderDetail");

                    b.HasOne("Data.Models.Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId1");
                });

            modelBuilder.Entity("Data.Models.Picture", b =>
                {
                    b.HasOne("Data.Models.Laptop")
                        .WithMany("Pictures")
                        .HasForeignKey("LaptopId")
                        .HasConstraintName("FK_Picture_Laptop");

                    b.HasOne("Data.Models.Laptop", "Laptop")
                        .WithMany()
                        .HasForeignKey("LaptopId1");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.HasOne("Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Role");

                    b.HasOne("Data.Models.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId1");
                });
#pragma warning restore 612, 618
        }
    }
}
