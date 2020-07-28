using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    [ScopedService]
    public interface IProductItemService
    {
        Task<ProductItem> GetProductItemAsync(int id);
        Task<List<ProductItem>> GetAllProductItemAsync();
        Task<ProductItem> AddProductItemAsync(ProductItem productItem);
        Task<ProductItem> UpdateProductItemAsync(ProductItem productItem);
        Task<ProductItem> DeleteProductItemAsync(int id);
        Task<List<ProductItem>> GetAllByProductIdAsync(int id);
    }
}
