using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class OrderItemViewModel
    {
        [Key]
        public int Id { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderViewModel Order { get; set; }

        public int? ProductItemId { get; set; }

        [ForeignKey("ProductItemId")]
        public virtual ProductItemViewModel ProductItem { get; set; }

        public int? CustomizeProductId { get; set; }

        //[ForeignKey("CustomizeProductId")]
        //public virtual CustomizeProductViewModel CustomizeProduct { get; set; }

        public int? ComboMealId { get; set; }

        [ForeignKey("ComboMealId")]
        public virtual ComboMealViewModel ComboMeal { get; set; }
    }
}
