using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCartItem> GetAsync(int shoppingCartItemId)
        {
            return await _shoppingCartRepository.GetAsync(shoppingCartItemId);
        }

        public async Task<ShoppingCartItem> GetCartAsync(string shoppingCartId)
        {
            return await _shoppingCartRepository.GetCartAsync(shoppingCartId);
        }

        public async Task<ShoppingCartItem> GetProductItemInCartAsync(string shoppingCartId, int id)
        {
            return await _shoppingCartRepository.GetProductItemInCartAsync(shoppingCartId, id);
        }

        public async Task AddToCartAsync(ProductItem productItem, ComboMeal comboMeal, CustomizeProduct customizeProduct, int quantity, string shoppingCartId)
        {
            await _shoppingCartRepository.AddToCartAsync(productItem, comboMeal, customizeProduct, quantity, shoppingCartId);
        }

        public async Task ClearCart(string shoppingCartId)
        {
            await _shoppingCartRepository.ClearCart(shoppingCartId);
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItems(string shoppingCartId)
        {
            return await _shoppingCartRepository.GetShoppingCartItems(shoppingCartId);
        }

        public double GetShoppingCartTotal(string shoppingCartId)
        {
            return _shoppingCartRepository.GetShoppingCartTotal(shoppingCartId);
        }

        public async Task<bool> RemoveFromCart(int shoppingCartItemId)
        {
            return await _shoppingCartRepository.RemoveFromCart(shoppingCartItemId);
        }
    }
}
