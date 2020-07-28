using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class CustomizeProductViewModel
    {
        public ProductItemViewModel ProductItemViewModel { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }

        public int Quantity { get; set; }
    }
}
