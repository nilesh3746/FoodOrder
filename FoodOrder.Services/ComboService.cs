using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class ComboService : IComboService
    {
        private readonly IComboRepository _comboRepository;
        private readonly IComboProductRepository _comboProductRepository;

        public ComboService(IComboRepository comboRepository, IComboProductRepository comboProductRepository)
        {
            _comboRepository = comboRepository;
            _comboProductRepository = comboProductRepository;
        }

        public async Task<ComboMeal> GetAsync(int id)
        {
            return await _comboRepository.GetAsync(id);
        }

        public async Task<ComboMeal> AddComboMealAsync(ComboMeal comboMeal)
        {
            return await _comboRepository.AddAsync(comboMeal);
        }

        public async Task<ComboMeal> DeleteComboMealAsync(int id)
        {
            return await _comboRepository.DeleteAsync(id);
        }

        public async Task<List<Combos>> GetAllComboMealAsync()
        {
            try
            {
                //var comboMeals = await _comboRepository.GetAllAsync();
                //var output = (from comboMeal in comboMeals
                //              select new Combos
                //              {
                //                  ComboMeal = comboMeal,
                //                  ComboProducts = _comboProductRepository.GetAllByIdAsync(comboMeal.Id).Result
                //              }).ToList();
                //return output;

                var comboProducts = await _comboProductRepository.GetAllComboProductsAsync();

                var output = comboProducts.GroupBy(x => x.ComboMeal)
                              .Select(x => new Combos
                              {
                                  ComboMeal = x.Key,
                                  ComboProducts = _comboProductRepository.GetAllByIdAsync(x.Key.Id).Result
                              }).ToList();
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Combos> GetComboMealAsync(int id)
        {
            return new Combos()
            {
                ComboMeal = await _comboRepository.GetAsync(id),
                ComboProducts = await _comboProductRepository.GetAllByIdAsync(id)
            };
        }

        public async Task<List<ComboMeal>> GetAllAsync()
        {
            return await _comboRepository.GetAllAsync();
        }
    }
}
