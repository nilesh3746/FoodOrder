using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    [ScopedService]
    public interface IComboService 
    {
        Task<ComboMeal> GetAsync(int id);
        Task<List<ComboMeal>> GetAllAsync();

        /// <summary>
        /// Get combo Meal and product Items for that combo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Combos> GetComboMealAsync(int id);
        Task<List<Combos>> GetAllComboMealAsync();
        Task<ComboMeal> AddComboMealAsync(ComboMeal comboMeal);
        Task<ComboMeal> DeleteComboMealAsync(int id);
    }
}
