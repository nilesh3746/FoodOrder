using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories
{
    public class CustomizeProductRepository : Repository<CustomizeProduct>, ICustomizeProductRepository
    {
        public CustomizeProductRepository(FoodDbContext context) : base(context)
        {

        }
    }
}
