using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    [ScopedService]
    public interface IShoppingCartService
    {
        Task<ShoppingCartItem> GetAsync(int shoppingCartItemId);
        Task<ShoppingCartItem> GetCartAsync(string shoppingCartId);
        Task<ShoppingCartItem> GetProductItemInCartAsync(string shoppingCartId, int id);
        Task AddToCartAsync(ProductItem productItem, ComboMeal comboMeal, CustomizeProduct customizeProduct, int quantity, string shoppingCartId);
        Task<bool> RemoveFromCart(int shoppingCartItemId);
        Task<List<ShoppingCartItem>> GetShoppingCartItems(string shoppingCartId);
        Task ClearCart(string shoppingCartId);
        double GetShoppingCartTotal(string shoppingCartId);
    }
}
