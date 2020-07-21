using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models.ViewModels
{
    [NotMapped]
    public class CombosViewModel
    {
        public ComboMealViewModel ComboMeal { get; set; }
        public List<ComboProductViewModel> ComboProducts { get; set; }
    }
}
