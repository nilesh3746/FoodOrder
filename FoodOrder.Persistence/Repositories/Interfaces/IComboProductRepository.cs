using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories.Interfaces
{
    [ScopedService]
    public interface IComboProductRepository : IRepository<ComboProduct>
    {
        Task<ComboProduct> GetComboProductsAsync(int id);
        Task<List<ComboProduct>> GetAllComboProductsAsync();
        Task<List<ComboProduct>> GetAllByIdAsync(int id);
        Task<List<ComboProduct>> AddComboProductRangeAsync(List<ComboProduct> comboProducts);
        Task<List<ComboProduct>> GetAllByProductItemIdAsync(int id);
    }
}
