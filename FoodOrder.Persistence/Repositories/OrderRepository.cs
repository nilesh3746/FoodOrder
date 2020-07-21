using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly FoodDbContext _context;

        public OrderRepository(FoodDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            try
            {
                return await _context.Orders.Include(x => x.Customer).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            try
            {
                return await _context.Orders.Include(x => x.Customer).Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entity");
            }
        }
    }
}
