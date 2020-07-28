using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class ShoppingCartItemViewModel
    {
        public int ShoppingCartItemId { get; set; }
        public ProductItemViewModel ProductItem { get; set; }
        public ComboMealViewModel ComboMeal { get; set; }
        public CustomizeProduct CustomizeProduct { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
