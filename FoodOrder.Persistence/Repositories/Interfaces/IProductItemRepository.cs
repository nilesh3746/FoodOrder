using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories.Interfaces
{
    public interface IProductItemRepository : IRepository<ProductItem>
    {
        Task<ProductItem> GetProductItemsAsync(int id);
        Task<List<ProductItem>> GetAllByProductIdAsync(int id);
        Task<List<ProductItem>> GetAllProductItemsAsync();
    }
}
