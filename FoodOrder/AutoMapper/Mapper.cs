using AutoMapper;
using FoodOrder.Models;
using FoodOrder.Models.ViewModels;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductItem, ProductItemViewModel>().ReverseMap();
            CreateMap<Ingredient, IngredientViewModel>().ReverseMap();
            CreateMap<ComboMeal, ComboMealViewModel>().ReverseMap();
            CreateMap<ComboProduct, ComboProductViewModel>().ReverseMap();
            CreateMap<Combos, CombosViewModel>().ReverseMap();
        }
    }
}
