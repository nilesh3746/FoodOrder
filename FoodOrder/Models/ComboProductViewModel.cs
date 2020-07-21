using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class ComboProductViewModel
    {
        [Key]
        public int Id { get; set; }

        public int ComboId { get; set; }

        [ForeignKey("ComboId")]
        public virtual ComboMealViewModel ComboMeal { get; set; }

        public int ProductItemId { get; set; }

        [ForeignKey("ProductItemId")]
        public virtual ProductItemViewModel ProductItem { get; set; }
    }
}
