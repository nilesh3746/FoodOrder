using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories
{
    public class ComboRepository : Repository<ComboMeal>, IComboRepository
    {
        private readonly FoodDbContext _context;

        public ComboRepository(FoodDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
