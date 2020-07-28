using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class CustomizeProduct
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int? ProductItemId { get; set; }

        [ForeignKey("ProductItemId")]
        public virtual ProductItem ProductItem { get; set; }

        //public int? ComboMealId { get; set; }

        //[ForeignKey("ComboMealId")]
        //public virtual ComboMeal ComboMeal { get; set; }
    }
}
