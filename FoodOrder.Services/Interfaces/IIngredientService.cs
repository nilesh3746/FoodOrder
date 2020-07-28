using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    [ScopedService]
    public interface IIngredientService
    {
        Task<Ingredient> GetIngredientAsync(int id);
        Task<List<Ingredient>> GetAllIngredientAsync();
        Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
        Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
        Task<Ingredient> DeleteIngredientAsync(int id);
    }
}
