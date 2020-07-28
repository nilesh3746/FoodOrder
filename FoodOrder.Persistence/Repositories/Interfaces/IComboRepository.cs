using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories.Interfaces
{
    [ScopedService]
    public interface IComboRepository : IRepository<ComboMeal> 
    {
        //Task<ComboMeal> GetComboMealAsync(int id);

        //Task<List<ComboMeal>> GetAllComboMealAsync();

        //Task<ComboMeal> AddComboMealAsync(ComboMeal comboMeal);

        //Task<ComboMeal> UpdateComboMealAsync(ComboMeal comboMeal);

        //Task<ComboMeal> DeleteComboMealAsync(int id);

    }
}
