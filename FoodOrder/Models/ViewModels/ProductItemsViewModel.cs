using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models.ViewModels
{
    public class ProductItemsViewModel
    {
        public ProductItemViewModel ProductItemViewModel { get; set; }

        public List<ProductViewModel> ProductViewModels { get; set; }
    }
}
