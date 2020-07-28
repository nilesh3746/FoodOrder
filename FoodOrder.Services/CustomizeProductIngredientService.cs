using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class CustomizeProductIngredientService : ICustomizeProductIngredientService
    {
        private readonly ICustomizeProductIngredientRepository _customizeProductIngredientRepository;

        public CustomizeProductIngredientService(ICustomizeProductIngredientRepository customizeProductIngredientRepository)
        {
            _customizeProductIngredientRepository = customizeProductIngredientRepository;
        }

        public async Task<CustomizeProductIngredients> AddCustomizeProductIngredientAsync(CustomizeProductIngredients customizeProductIngredients)
        {
            return await _customizeProductIngredientRepository.AddAsync(customizeProductIngredients);
        }

        public async Task<CustomizeProductIngredients> DeleteCustomizeProductIngredientAsync(int id)
        {
            return await _customizeProductIngredientRepository.DeleteAsync(id);
        }
    }
}
