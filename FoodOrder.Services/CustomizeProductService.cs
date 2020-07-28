using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class CustomizeProductService : ICustomizeProductService
    {
        private readonly ICustomizeProductRepository _customizeProductRepository;

        public CustomizeProductService(ICustomizeProductRepository customizeProductRepository)
        {
            _customizeProductRepository = customizeProductRepository;
        }

        public async Task<CustomizeProduct> AddCustomizeProductAsync(CustomizeProduct customizeProduct)
        {
            return await _customizeProductRepository.AddAsync(customizeProduct);
        }

        public async Task<CustomizeProduct> DeleteCustomizeProductAsync(int id)
        {
            return await _customizeProductRepository.DeleteAsync(id);
        }
    }
}
