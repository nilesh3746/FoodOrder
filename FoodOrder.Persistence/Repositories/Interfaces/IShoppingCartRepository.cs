using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories.Interfaces
{
    [ScopedService]
    public interface IShoppingCartRepository : IRepository<ShoppingCartItem>
    {
        Task<ShoppingCartItem> GetCartAsync(string shoppingCartId);

        Task AddToCartAsync(ProductItem productItem, ComboMeal comboMeal, CustomizeProduct customizeProduct, int quantity, string shoppingCartId);

        Task<bool> RemoveFromCart(int shoppingCartItemId);

        Task<List<ShoppingCartItem>> GetShoppingCartItems(string shoppingCartId);

        Task<ShoppingCartItem> GetProductItemInCartAsync(string shoppingCartId, int id);

        Task ClearCart(string shoppingCartId);

        double GetShoppingCartTotal(string shoppingCartId);
    }
}
