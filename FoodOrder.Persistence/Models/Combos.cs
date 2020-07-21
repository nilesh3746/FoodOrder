using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    [NotMapped]
    public class Combos
    {
        public ComboMeal ComboMeal { get; set; }

        public List<ComboProduct> ComboProducts { get; set; }
    }
}
