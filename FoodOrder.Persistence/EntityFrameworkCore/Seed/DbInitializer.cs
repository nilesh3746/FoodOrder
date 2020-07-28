using FoodOrder.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrder.Persistence.EntityFrameworkCore.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(FoodDbContext context, IServiceProvider service)
        {
            context.Database.EnsureCreated();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = service.GetRequiredService<UserManager<IdentityUser>>();

            //ClearDatabase(context);
            CreateAdminRole(context, roleManager, userManager);
            //SeedDatabase(context);
        }

        private static void CreateAdminRole(FoodDbContext context, RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            bool roleExists = _roleManager.RoleExistsAsync("Admin").Result;
            if (roleExists)
            {
                return;
            }

            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            _roleManager.CreateAsync(role).Wait();

            var userRole = new IdentityRole()
            {
                Name = "User"
            };
            _roleManager.CreateAsync(userRole).Wait();

            var user = new IdentityUser()
            {
                UserName = "admin@default.com",
                Email = "admin@default.com"
            };

            string adminPassword = "Password@123";
            var userResult = _userManager.CreateAsync(user, adminPassword).Result;

            if (userResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }

            context.SaveChanges();
        }

        private static void SeedDatabase(FoodDbContext _context)
        {
            var productCategories = new List<Product>()
            {
                new Product() { Name = "Pizza", Description = null },
                new Product() { Name = "Sandwich", Description = null },
                new Product() { Name = "Coke", Description = null }
            };

            var productItems = new List<ProductItem>()
            {
                new ProductItem() { Name = "Veg Pizza", Description = null, Price = 60, ProductId = 1 },
                new ProductItem() { Name = "Non-Veg Pizza", Description = null, Price = 90, ProductId = 1 },
                new ProductItem() { Name = "Bombay Sandwich", Description = null, Price = 70, ProductId = 2 },
                new ProductItem() { Name = "Plain Sandwich", Description = null, Price = 40, ProductId = 2 },
                new ProductItem() { Name = "Pepsi", Description = null, Price = 35, ProductId = 3 },
                new ProductItem() { Name = "Coco Cola", Description = null, Price = 35, ProductId = 3 }
            };

            var combos = new List<ComboMeal>()
            {
                new ComboMeal() { Name = "Veg Pizza + Pepsi", Description = null, Price = 90 },
                new ComboMeal() { Name = "Non-Veg Pizza + Coco Cola", Description = null, Price = 120 },
                new ComboMeal() { Name = "Bombay Sandwich + Pepsi", Description = null, Price = 100 },
                new ComboMeal() { Name = "Plain Sandwich + Coco cocla", Description = null, Price = 70 },
                new ComboMeal() { Name = "Veg Pizza + Plain Sandwich + Coco cocla", Description = null, Price = 120 }
            };

            var comboProducts = new List<ComboProduct>()
            {
                new ComboProduct() { ComboId = 1, ProductItemId = 1 },
                new ComboProduct() { ComboId = 1, ProductItemId = 5 },
                new ComboProduct() { ComboId = 2, ProductItemId = 2 },
                new ComboProduct() { ComboId = 2, ProductItemId = 6 },
                new ComboProduct() { ComboId = 3, ProductItemId = 3 },
                new ComboProduct() { ComboId = 3, ProductItemId = 5 },
                new ComboProduct() { ComboId = 4, ProductItemId = 4 },
                new ComboProduct() { ComboId = 4, ProductItemId = 6 },
                new ComboProduct() { ComboId = 5, ProductItemId = 1 },
                new ComboProduct() { ComboId = 5, ProductItemId = 4 },
                new ComboProduct() { ComboId = 5, ProductItemId = 6 }
            };

            var ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "PizzaToast", Description = null, Price = 10 },
                new Ingredient() { Name = "Bread", Description = null, Price = 10 },
                new Ingredient() { Name = "Topping", Description = null, Price = 20 },
                new Ingredient() { Name = "Sauce", Description = null, Price = 10 },
                new Ingredient() { Name = "Cheese", Description = null, Price = 10 }
            };

            _context.Products.AddRange(productCategories);
            _context.ProductItems.AddRange(productItems);
            _context.Ingredients.AddRange(ingredients);
            _context.ComboMeals.AddRange(combos);
            //_context.ComboProducts.AddRange(comboProducts);

            _context.SaveChanges();
        }

        private static void ClearDatabase(FoodDbContext _context)
        {
            var productCategories = _context.Products.ToList();
            _context.Products.RemoveRange(productCategories);

            var productItems = _context.ProductItems.ToList();
            _context.ProductItems.RemoveRange(productItems);

            var orderItems = _context.OrderItems.ToList();
            _context.OrderItems.RemoveRange(orderItems);

            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);

            var customers = _context.Customers.ToList();
            _context.Customers.RemoveRange(customers);

            //var users = _context.Users.ToList();
            //var userRoles = _context.UserRoles.ToList();

            //foreach (var user in users)
            //{
            //    if (!userRoles.Any(r => r.UserId == user.Id))
            //    {
            //        _context.Users.Remove(user);
            //    }
            //}

            _context.SaveChanges();
        }
    }
}
