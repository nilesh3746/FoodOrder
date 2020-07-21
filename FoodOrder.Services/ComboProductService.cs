using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class ComboProductService : IComboProductService
    {
        private readonly IComboProductRepository _comboProductRepository;

        public ComboProductService(IComboProductRepository comboProductRepository)
        {
            _comboProductRepository = comboProductRepository;
        }

        public async Task<List<ComboProduct>> GetAllByProductItemIdAsync(int id)
        {
            return await _comboProductRepository.GetAllByProductItemIdAsync(id);
        }

        public async Task<List<ComboProduct>> AddComboProductRangeAsync(List<ComboProduct> comboProducts)
        {
            return await _comboProductRepository.AddComboProductRangeAsync(comboProducts);
        }
    }
}
