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
    public class ComboProductRepository : Repository<ComboProduct>, IComboProductRepository
    {
        private readonly FoodDbContext _context;

        public ComboProductRepository(FoodDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ComboProduct> GetComboProductsAsync(int id)
        {
            try
            {
                return await _context.ComboProducts.Include(x => x.ComboMeal).Include(x => x.ProductItem).Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entity");
            }
        }

        public async Task<List<ComboProduct>> GetAllComboProductsAsync()
        {
            try
            {
                return await _context.ComboProducts.Include(x => x.ComboMeal).Include(x => x.ProductItem).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<List<ComboProduct>> GetAllByIdAsync(int id)
        {
            try
            {
                return await _context.ComboProducts.Include(x => x.ProductItem).Where(x => x.ComboId == id).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<List<ComboProduct>> AddComboProductRangeAsync(List<ComboProduct> comboProducts)
        {
            if (!comboProducts.Any())
            {
                throw new ArgumentNullException($"{nameof(AddComboProductRangeAsync)} entity must not be null");
            }

            try
            {
                await _context.AddRangeAsync(comboProducts);
                await _context.SaveChangesAsync();

                return comboProducts;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(comboProducts)} could not be saved");
            }
        }

        public async Task<List<ComboProduct>> GetAllByProductItemIdAsync(int id)
        {
            try
            {
                return await _context.ComboProducts.Where(x => x.ProductItemId == id).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
