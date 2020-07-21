using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly FoodDbContext _repositoryFoodDbContext;

        public Repository(FoodDbContext foodDbContext)
        {
            _repositoryFoodDbContext = foodDbContext;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            try
            {
                return await _repositoryFoodDbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entity");
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _repositoryFoodDbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _repositoryFoodDbContext.AddAsync(entity);
                await _repositoryFoodDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _repositoryFoodDbContext.Update(entity);
                await _repositoryFoodDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            try { 
            var entity = await _repositoryFoodDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _repositoryFoodDbContext.Set<TEntity>().Remove(entity);
            await _repositoryFoodDbContext.SaveChangesAsync();

            return entity;
            }
            catch (Exception)
            {
                throw new Exception($"There is no record for id: {id}");
            }
        }
    }
}
