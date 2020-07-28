using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories
{
    [ScopedService]
    public interface ICustomizeProductIngredientRepository : IRepository<CustomizeProductIngredients>
    {
    }
}
