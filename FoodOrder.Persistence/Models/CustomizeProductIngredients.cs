using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class CustomizeProductIngredients
    {
        [Key]
        public int Id { get; set; }

        public int CustomizeProductId { get; set; }

        [ForeignKey("CustomizeProductId")]
        public virtual CustomizeProduct CustomizeProduct { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredients { get; set; }
    }
}
