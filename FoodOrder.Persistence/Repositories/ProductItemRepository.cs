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
    public class ProductItemRepository : Repository<ProductItem>, IProductItemRepository
    {
        private readonly FoodDbContext _context;

        public ProductItemRepository(FoodDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductItem>> GetAllProductItemsAsync()
        {
            try
            {
                return await _context.ProductItems.Include(x => x.Product).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve product items");
            }
        }

        public async Task<ProductItem> GetProductItemsAsync(int id)
        {
            try
            {
                return await _context.ProductItems.Include(x => x.Product).Where(x=>x.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve product item");
            }
        }

        public async Task<List<ProductItem>> GetAllByProductIdAsync(int id)
        {
            try
            {
                return await _context.ProductItems.Include(x => x.Product).Where(x => x.ProductId == id).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve product item");
            }
        }
    }
}
