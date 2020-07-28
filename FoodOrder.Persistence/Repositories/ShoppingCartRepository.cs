using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodOrder.Persistence.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCartItem>, IShoppingCartRepository
    {
        private readonly FoodDbContext _context;

        public ShoppingCartRepository(FoodDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ShoppingCartItem> GetCartAsync(string shoppingCartId)
        {
            return await _context.ShoppingCartItems.Where(x => x.ShoppingCartId == shoppingCartId).FirstOrDefaultAsync();
        }

        public async Task AddToCartAsync(ProductItem productItem, ComboMeal comboMeal, CustomizeProduct customizeProduct, int quantity, string shoppingCartId)
        {
            try
            {
                if (productItem != null)
                {
                    var shoppingCartItem = await _context.ShoppingCartItems.SingleOrDefaultAsync(
                                    s => s.ShoppingCartId == shoppingCartId &&
                                    s.ProductItemId == productItem.Id);

                    if (shoppingCartItem == null)
                    {
                        shoppingCartItem = new ShoppingCartItem
                        {
                            ShoppingCartId = shoppingCartId,
                            ProductItem = productItem,
                            ComboMeal = null,
                            CustomizeProduct = null,
                            Quantity = quantity
                        };
                        await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
                    }
                    else
                    {
                        shoppingCartItem.Quantity = quantity;
                    }
                }

                if (comboMeal != null)
                {
                    var shoppingCartItem = await _context.ShoppingCartItems.SingleOrDefaultAsync(
                                    s => s.ShoppingCartId == shoppingCartId &&
                                    s.ComboMealId == comboMeal.Id);

                    if (shoppingCartItem == null)
                    {
                        shoppingCartItem = new ShoppingCartItem
                        {
                            ShoppingCartId = shoppingCartId,
                            ProductItem = null,
                            ComboMeal = comboMeal,
                            CustomizeProduct = null,
                            Quantity = quantity
                        };
                        await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
                    }
                    else
                    {
                        shoppingCartItem.Quantity = quantity;
                    }
                }

                if (customizeProduct != null)
                {
                    var shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartId = shoppingCartId,
                        ProductItem = null,
                        ComboMeal = null,
                        CustomizeProduct = customizeProduct,
                        Quantity = quantity
                    };
                    await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveFromCart(int shoppingCartItemId)
        {
            try
            {
                ShoppingCartItem shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                                        s => s.ShoppingCartItemId == shoppingCartItemId);

                if (shoppingCartItem != null)
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItems(string shoppingCartId)
        {
            try
            {
                return await _context.ShoppingCartItems.Where(c => c.ShoppingCartId == shoppingCartId)
                               .Include(s => s.ProductItem)
                               .Include(x => x.ComboMeal)
                               .Include(x => x.CustomizeProduct)
                               .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ShoppingCartItem> GetProductItemInCartAsync(string shoppingCartId, int id)
        {
            return await _context.ShoppingCartItems.Where(x => x.ShoppingCartId == shoppingCartId && x.ProductItemId == id).FirstOrDefaultAsync();
        }

        public async Task ClearCart(string shoppingCartId)
        {
            try
            {
                var cartItems = _context.ShoppingCartItems
                                .Where(cart => cart.ShoppingCartId == shoppingCartId);

                _context.ShoppingCartItems.RemoveRange(cartItems);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public double GetShoppingCartTotal(string shoppingCartId)
        {
            try
            {
                var productItemTotal = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == shoppingCartId && c.ProductItemId != null)
                                        .Select(c => c.ProductItem.Price * c.Quantity).Sum();

                var comboMealTotal = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == shoppingCartId && c.ComboMealId != null)
                                        .Select(c => c.ComboMeal.Price * c.Quantity).Sum();

                var customizeProductTotal = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == shoppingCartId && c.CustomizeProductId != null)
                                        .Select(c => c.CustomizeProduct.Price * c.Quantity).Sum();

                return productItemTotal + comboMealTotal + customizeProductTotal;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
