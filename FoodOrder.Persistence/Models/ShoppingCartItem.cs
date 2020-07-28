using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public int? ProductItemId { get; set; }
        [ForeignKey("ProductItemId")]
        public virtual ProductItem ProductItem { get; set; }

        public int? ComboMealId { get; set; }
        [ForeignKey("ComboMealId")]
        public virtual ComboMeal ComboMeal { get; set; }

        public int? CustomizeProductId { get; set; }
        [ForeignKey("CustomizeProductId")]
        public virtual CustomizeProduct CustomizeProduct { get; set; }

        public int Quantity { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
