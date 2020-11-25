﻿// <auto-generated />
using AshrafsSweetShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AshrafsSweetShop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20201124115259_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AshrafsSweetShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Chocolates"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Fruit Candy"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Gummy Candy"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Halloween Candy"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Hard Candy"
                        });
                });

            modelBuilder.Entity("AshrafsSweetShop.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryId = 1,
                            Code = "Chocolate_Assorted",
                            Name = "Assorted Chocolate",
                            Price = 4.99m
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryId = 1,
                            Code = "Chocolate_Mixed",
                            Name = "Chocolate Mixed Candy",
                            Price = 5.99m
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryId = 1,
                            Code = "Chocolate_MMS",
                            Name = "M&M",
                            Price = 3.75m
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryId = 2,
                            Code = "Fruit_Chewy",
                            Name = "Chewy Fruit Candy",
                            Price = 6.9m
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryId = 2,
                            Code = "Fruit_Pops",
                            Name = "Fruit Lolli Pops",
                            Price = 2.9m
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryId = 2,
                            Code = "Fruit_Sour",
                            Name = "Sour Fruit Candy",
                            Price = 4.95m
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryId = 3,
                            Code = "Gummy_Import",
                            Name = "Imported Gummy Candy",
                            Price = 11.9m
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryId = 3,
                            Code = "Gummy_Sour",
                            Name = "Gummy Sour Candy",
                            Price = 1.9m
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryId = 3,
                            Code = "Gummy_Traditional",
                            Name = "Traditional Gummy Candy",
                            Price = 2.9m
                        },
                        new
                        {
                            ProductID = 10,
                            CategoryId = 4,
                            Code = "Halloween_Assorted",
                            Name = "Assorted Halloween Candy",
                            Price = 3.5m
                        },
                        new
                        {
                            ProductID = 11,
                            CategoryId = 4,
                            Code = "Halloween_Orange",
                            Name = "Halloween Orange Cones",
                            Price = 4.33m
                        },
                        new
                        {
                            ProductID = 12,
                            CategoryId = 4,
                            Code = "Halloween_Red",
                            Name = "Halloween Red Cones",
                            Price = 3.98m
                        },
                        new
                        {
                            ProductID = 13,
                            CategoryId = 5,
                            Code = "Hard_Fruit",
                            Name = "Hard Fruit Candy",
                            Price = 9.9m
                        },
                        new
                        {
                            ProductID = 14,
                            CategoryId = 5,
                            Code = "Hard_Assorted",
                            Name = "Hard Assorted Candy",
                            Price = 8.97m
                        },
                        new
                        {
                            ProductID = 15,
                            CategoryId = 5,
                            Code = "Hard_Sour",
                            Name = "Sour Hard Candy",
                            Price = 5.55m
                        });
                });

            modelBuilder.Entity("AshrafsSweetShop.Models.Product", b =>
                {
                    b.HasOne("AshrafsSweetShop.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
