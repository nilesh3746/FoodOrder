using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Models.ViewModels
{
    public class ComboProductsViewModel
    {
        public ComboMealViewModel ComboMeal { get; set; }
        public int[] ProductItemIds { get; set; }
        public List<ProductItemViewModel> ProductItems { get; set; }
    }
}
