using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models.ViewModels
{
    public class ShoppingViewModel
    {
        public ShoppingCartViewModel ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
