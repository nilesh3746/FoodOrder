using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            return await _ingredientRepository.AddAsync(ingredient);
        }

        public async Task<Ingredient> DeleteIngredientAsync(int id)
        {
            return await _ingredientRepository.DeleteAsync(id);
        }

        public async Task<List<Ingredient>> GetAllIngredientAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }

        public async Task<Ingredient> GetIngredientAsync(int id)
        {
            return await _ingredientRepository.GetAsync(id);
        }

        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
            return await _ingredientRepository.UpdateAsync(ingredient);
        }
    }
}
