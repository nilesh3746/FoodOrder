using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    public interface IComboService 
    {
        Task<Combos> GetComboMealAsync(int id);

        Task<List<Combos>> GetAllComboMealAsync();

        Task<ComboMeal> AddComboMealAsync(ComboMeal comboMeal);

        Task<ComboMeal> DeleteComboMealAsync(int id);
    }
}
