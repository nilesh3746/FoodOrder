﻿// <auto-generated />
using System;
using FoodOrder.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodOrder.Persistence.Migrations
{
    [DbContext(typeof(FoodDbContext))]
    partial class FoodDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodOrder.Persistence.Models.ComboMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ComboMeals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Veg Pizza + Pepsi",
                            Price = 90.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Non-Veg Pizza + Coco Cola",
                            Price = 120.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bombay Sandwich + Pepsi",
                            Price = 100.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Plain Sandwich + Coco cocla",
                            Price = 70.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Veg Pizza + Plain Sandwich + Coco cocla",
                            Price = 120.0
                        });
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.ComboProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComboId");

                    b.HasIndex("ProductItemId");

                    b.ToTable("ComboProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ComboId = 1,
                            ProductItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            ComboId = 1,
                            ProductItemId = 5
                        },
                        new
                        {
                            Id = 3,
                            ComboId = 2,
                            ProductItemId = 2
                        },
                        new
                        {
                            Id = 4,
                            ComboId = 2,
                            ProductItemId = 6
                        },
                        new
                        {
                            Id = 5,
                            ComboId = 3,
                            ProductItemId = 3
                        },
                        new
                        {
                            Id = 6,
                            ComboId = 3,
                            ProductItemId = 5
                        },
                        new
                        {
                            Id = 7,
                            ComboId = 4,
                            ProductItemId = 4
                        },
                        new
                        {
                            Id = 8,
                            ComboId = 4,
                            ProductItemId = 6
                        },
                        new
                        {
                            Id = 9,
                            ComboId = 5,
                            ProductItemId = 1
                        },
                        new
                        {
                            Id = 10,
                            ComboId = 5,
                            ProductItemId = 4
                        },
                        new
                        {
                            Id = 11,
                            ComboId = 5,
                            ProductItemId = 6
                        });
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.CustomizeProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductItemId");

                    b.ToTable("CustomizeProducts");
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.CustomizeProductIngredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomizeProductId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomizeProductId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CustomizeProductIngredients");
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PizzaToast",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bread",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Topping",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sauce",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cheese",
                            Price = 10.0
                        });
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComboMealId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomizeProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ComboMealId");

                    b.HasIndex("CustomizeProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sandwich"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Coke"
                        });
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Veg Pizza",
                            Price = 60.0,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Non-Veg Pizza",
                            Price = 90.0,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bombay Sandwich",
                            Price = 70.0,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Plain Sandwich",
                            Price = 40.0,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pepsi",
                            Price = 35.0,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Coco Cola",
                            Price = 35.0,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.ComboProduct", b =>
                {
                    b.HasOne("FoodOrder.Persistence.Models.ComboMeal", "ComboMeal")
                        .WithMany()
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrder.Persistence.Models.ProductItem", "ProductItem")
                        .WithMany()
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.CustomizeProduct", b =>
                {
                    b.HasOne("FoodOrder.Persistence.Models.ProductItem", "ProductItem")
                        .WithMany()
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.CustomizeProductIngredients", b =>
                {
                    b.HasOne("FoodOrder.Persistence.Models.CustomizeProduct", "CustomizeProduct")
                        .WithMany()
                        .HasForeignKey("CustomizeProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrder.Persistence.Models.Ingredient", "Ingredients")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.Order", b =>
                {
                    b.HasOne("FoodOrder.Persistence.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.OrderItem", b =>
                {
                    b.HasOne("FoodOrder.Persistence.Models.ComboMeal", "ComboMeal")
                        .WithMany()
                        .HasForeignKey("ComboMealId");

                    b.HasOne("FoodOrder.Persistence.Models.CustomizeProduct", "CustomizeProduct")
                        .WithMany()
                        .HasForeignKey("CustomizeProductId");

                    b.HasOne("FoodOrder.Persistence.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOrder.Persistence.Models.ProductItem", "ProductItem")
                        .WithMany()
                        .HasForeignKey("ProductItemId");
                });

            modelBuilder.Entity("FoodOrder.Persistence.Models.ProductItem", b =>
                {
                    b.HasOne("FoodOrder.Persistence.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
