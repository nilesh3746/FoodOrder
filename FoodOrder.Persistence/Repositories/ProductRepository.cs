using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly FoodDbContext _context;

        public ProductRepository(FoodDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
