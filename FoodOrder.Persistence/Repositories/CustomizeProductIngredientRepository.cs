using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories
{
    public class CustomizeProductIngredientRepository : Repository<CustomizeProductIngredients>, ICustomizeProductIngredientRepository
    {
        public CustomizeProductIngredientRepository(FoodDbContext context) : base(context)
        {

        }
    }
}
