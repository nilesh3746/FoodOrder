using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class SelectProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ProductCategory { get; set; }
        //public List<IngredientViewModel>  IngredientViewModels { get; set; }
    }
}
