using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int? ProductItemId { get; set; }

        [ForeignKey("ProductItemId")]
        public virtual ProductItem ProductItem { get; set; }

        public int? CustomizeProductId { get; set; }

        [ForeignKey("CustomizeProductId")]
        public virtual CustomizeProduct CustomizeProduct { get; set; }

        public int? ComboMealId { get; set; }

        [ForeignKey("ComboMealId")]
        public virtual ComboMeal ComboMeal { get; set; }

    }
}
