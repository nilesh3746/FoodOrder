using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class SelectCustomizeProductViewModel
    {
        public int ProductItemId { get; set; }
        public List<SelectIngredientViewModel> Ingredients { get; set; }
    }

    public class SelectIngredientViewModel
    {
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
    }
}
