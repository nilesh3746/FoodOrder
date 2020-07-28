using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
