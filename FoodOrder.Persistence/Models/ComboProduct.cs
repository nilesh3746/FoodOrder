using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class ComboProduct
    {
        [Key]
        public int Id { get; set; }

        public int ComboId { get; set; }

        [ForeignKey("ComboId")]
        public virtual ComboMeal ComboMeal { get; set; }

        public int ProductItemId { get; set; }

        [ForeignKey("ProductItemId")]
        public virtual ProductItem ProductItem { get; set; }
    }
}
