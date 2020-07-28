using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class ShoppingCartViewModel
    {
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
    }
}
