using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    public interface IComboProductService
    {
        Task<List<ComboProduct>> GetAllByProductItemIdAsync(int id);
        Task<List<ComboProduct>> AddComboProductRangeAsync(List<ComboProduct> comboProducts);
    }
}
