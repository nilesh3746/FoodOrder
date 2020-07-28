using FoodOrder.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.EntityFrameworkCore
{
    public class FoodDbContext : IdentityDbContext<IdentityUser>
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ComboMeal> ComboMeals { get; set; }
        public DbSet<ComboProduct> ComboProducts { get; set; }
        public DbSet<CustomizeProduct> CustomizeProducts { get; set; }
        public DbSet<CustomizeProductIngredients> CustomizeProductIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Add static data
            modelBuilder.Entity<Product>().HasData(
                            new Product() { Id = 1, Name = "Pizza", Description = null },
                            new Product() { Id = 2, Name = "Sandwich", Description = null },
                            new Product() { Id = 3, Name = "Coke", Description = null }
                        );

            modelBuilder.Entity<ProductItem>().HasData(
                            new ProductItem() { Id = 1, Name = "Veg Pizza", Description = null, Price = 60, ProductId = 1 },
                            new ProductItem() { Id = 2, Name = "Non-Veg Pizza", Description = null, Price = 90, ProductId = 1 },
                            new ProductItem() { Id = 3, Name = "Bombay Sandwich", Description = null, Price = 70, ProductId = 2 },
                            new ProductItem() { Id = 4, Name = "Plain Sandwich", Description = null, Price = 40, ProductId = 2 },
                            new ProductItem() { Id = 5, Name = "Pepsi", Description = null, Price = 35, ProductId = 3 },
                            new ProductItem() { Id = 6, Name = "Coco Cola", Description = null, Price = 35, ProductId = 3 }
                );

            modelBuilder.Entity<Ingredient>().HasData(
                            new Ingredient() { Id = 1, Name = "PizzaBase", Description = null, Price = 10 },
                            new Ingredient() { Id = 2, Name = "Bread", Description = null, Price = 10 },
                            new Ingredient() { Id = 3, Name = "Topping", Description = null, Price = 20 },
                            new Ingredient() { Id = 4, Name = "Sauce", Description = null, Price = 10 },
                            new Ingredient() { Id = 5, Name = "Cheese", Description = null, Price = 10 }
                        );

            modelBuilder.Entity<ComboMeal>().HasData(
                            new ComboMeal() { Id = 1, Name = "Veg Pizza + Pepsi", Description = null, Price = 90 },
                            new ComboMeal() { Id = 2, Name = "Non-Veg Pizza + Coco Cola", Description = null, Price = 120 },
                            new ComboMeal() { Id = 3, Name = "Bombay Sandwich + Pepsi", Description = null, Price = 100 },
                            new ComboMeal() { Id = 4, Name = "Plain Sandwich + Coco cocla", Description = null, Price = 70 },
                            new ComboMeal() { Id = 5, Name = "Veg Pizza + Plain Sandwich + Coco cocla", Description = null, Price = 120 }
                        );

            modelBuilder.Entity<ComboProduct>().HasData(
                            new ComboProduct() { Id = 1, ComboId = 1, ProductItemId = 1 },
                            new ComboProduct() { Id = 2, ComboId = 1, ProductItemId = 5 },
                            new ComboProduct() { Id = 3, ComboId = 2, ProductItemId = 2 },
                            new ComboProduct() { Id = 4, ComboId = 2, ProductItemId = 6 },
                            new ComboProduct() { Id = 5, ComboId = 3, ProductItemId = 3 },
                            new ComboProduct() { Id = 6, ComboId = 3, ProductItemId = 5 },
                            new ComboProduct() { Id = 7, ComboId = 4, ProductItemId = 4 },
                            new ComboProduct() { Id = 8, ComboId = 4, ProductItemId = 6 },
                            new ComboProduct() { Id = 9, ComboId = 5, ProductItemId = 1 },
                            new ComboProduct() { Id = 10, ComboId = 5, ProductItemId = 4 },
                            new ComboProduct() { Id = 11, ComboId = 5, ProductItemId = 6 }
                        );
            #endregion
        }
    }
}
