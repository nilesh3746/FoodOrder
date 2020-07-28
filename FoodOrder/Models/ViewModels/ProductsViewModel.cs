using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models.ViewModels
{
    public class ProductsViewModel
    {
        public List<SelectProductViewModel> SelecteProductViewModels { get; set; }
        public List<SelectComboProductViewModel> SelectComboProductViewModels { get; set; }
    }
}
