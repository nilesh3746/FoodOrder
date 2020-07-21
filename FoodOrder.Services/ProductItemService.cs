using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class ProductItemService : IProductItemService
    {
        private readonly IProductItemRepository _productItemRepository;

        public ProductItemService(IProductItemRepository productItemRepository)
        {
            _productItemRepository = productItemRepository;
        }

        public async Task<ProductItem> AddProductItemAsync(ProductItem productItem)
        {
            return await _productItemRepository.AddAsync(productItem);
        }

        public async Task<ProductItem> DeleteProductItemAsync(int id)
        {
            return await _productItemRepository.DeleteAsync(id);
        }

        public async Task<List<ProductItem>> GetAllProductItemAsync()
        {
            return await _productItemRepository.GetAllProductItemsAsync();
        }

        public async Task<ProductItem> GetProductItemAsync(int id)
        {
            return await _productItemRepository.GetProductItemsAsync(id);
        }

        public async Task<ProductItem> UpdateProductItemAsync(ProductItem productItem)
        {
            return await _productItemRepository.UpdateAsync(productItem);
        }

        public async Task<List<ProductItem>> GetAllByProductIdAsync(int id)
        {
            return await _productItemRepository.GetAllByProductIdAsync(id);
        }
    }
}
