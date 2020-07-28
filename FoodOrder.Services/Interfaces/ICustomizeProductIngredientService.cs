using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    [ScopedService]
    public interface ICustomizeProductIngredientService
    {
        Task<CustomizeProductIngredients> AddCustomizeProductIngredientAsync(CustomizeProductIngredients customizeProductIngredients);

        Task<CustomizeProductIngredients> DeleteCustomizeProductIngredientAsync(int id);
    }
}
