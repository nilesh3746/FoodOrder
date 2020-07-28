using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodOrder.Models;
using FoodOrder.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using FoodOrder.Persistence.Models;
using System;

namespace FoodOrder.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductItemService _productItemService;
        private readonly IComboService _comboService;
        private readonly IIngredientService _ingredientService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomizeProductService _customizeProductService;
        private readonly ICustomizeProductIngredientService _customizeProductIngredientService;

        public ShoppingCartSession Session { get; }

        public HomeController(IProductItemService productItemService, IComboService comboService, IIngredientService ingredientService, IShoppingCartService shoppingCartService, IMapper mapper, ILogger<HomeController> logger, ShoppingCartSession session, ICustomizeProductService customizeProductService, ICustomizeProductIngredientService customizeProductIngredientService)
        {
            _productItemService = productItemService;
            _comboService = comboService;
            _ingredientService = ingredientService;
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            _logger = logger;
            Session = session;
            _customizeProductService = customizeProductService;
            _customizeProductIngredientService = customizeProductIngredientService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var productItems = _mapper.Map<List<ProductItemViewModel>>(await _productItemService.GetAllProductItemAsync());
                var products = productItems.Select(x => new SelectProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ProductCategory = x.Product.Name,
                    Quantity = 1
                }).ToList();

                return View(products);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<SelectProductViewModel> selectProductViewModels)
        {
            if (selectProductViewModels.Any())
            {
                foreach (var item in selectProductViewModels)
                {
                    var prodItem = await _productItemService.GetProductItemAsync(item.Id);
                    await _shoppingCartService.AddToCartAsync(prodItem, null, null, item.Quantity, Session.ShoppingCartId);
                }
                return Json(selectProductViewModels?.Count);
            }
            return Json(0);
        }

        public async Task<IActionResult> ComboMeal()
        {
            var comboMeals = _mapper.Map<List<ComboMealViewModel>>(await _comboService.GetAllAsync());

            var combos = comboMeals.Select(x => new SelectComboProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = 1
            }).ToList();

            return View(combos);
        }

        [HttpPost]
        public async Task<IActionResult> ComboMeal(List<SelectComboProductViewModel> selectComboProductViewModels)
        {
            if (selectComboProductViewModels.Any())
            {
                foreach (var item in selectComboProductViewModels)
                {
                    var prodItem = await _comboService.GetAsync(item.Id);
                    await _shoppingCartService.AddToCartAsync(null, prodItem, null, item.Quantity, Session.ShoppingCartId);
                }
                return Json(selectComboProductViewModels?.Count);
            }
            return Json(0);
        }

        public async Task<IActionResult> CustomizeProduct(int id)
        {
            var productItem = _mapper.Map<ProductItemViewModel>(await _productItemService.GetProductItemAsync(id));
            var ingredients = _mapper.Map<List<IngredientViewModel>>(await _ingredientService.GetAllIngredientAsync());
            if (productItem.Product.Name == "Pizza")
            {
                ingredients.Remove(ingredients.Where(x => x.Name == "Bread").FirstOrDefault());
            }
            if (productItem.Product.Name == "Sandwich")
            {
                ingredients.Remove(ingredients.Where(x => x.Name == "PizzaBase").FirstOrDefault());
            }

            var customizeProductViewModel = new CustomizeProductViewModel()
            {
                ProductItemViewModel = productItem,
                Ingredients = ingredients,
                Quantity = 1
            };
            return View(customizeProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CustomizeProduct(SelectCustomizeProductViewModel selectCustomizeProductViewModel)
        {
            if (selectCustomizeProductViewModel.Ingredients.Any() && selectCustomizeProductViewModel.ProductItemId > 0)
            {
                double subTotal =0;
                var productItem = await _productItemService.GetProductItemAsync(selectCustomizeProductViewModel.ProductItemId);

                foreach (var item in selectCustomizeProductViewModel.Ingredients)
                {
                    var ingredient = await _ingredientService.GetIngredientAsync(item.IngredientId);
                    subTotal += ingredient.Price * item.Quantity; 
                }

                var total = productItem.Price + subTotal;

                var customizeProduct = new CustomizeProduct()
                {
                    Name = "Customize " + productItem.Name,
                    ProductItemId = selectCustomizeProductViewModel.ProductItemId,
                    Price = total
                };
                var customProduct = await _customizeProductService.AddCustomizeProductAsync(customizeProduct);

                foreach (var item in selectCustomizeProductViewModel.Ingredients)
                {
                    var customizeProductIngredient = new CustomizeProductIngredients()
                    {
                        CustomizeProductId = selectCustomizeProductViewModel.ProductItemId,
                        IngredientId = item.IngredientId
                    };
                    await _customizeProductIngredientService.AddCustomizeProductIngredientAsync(customizeProductIngredient);
                }

                await _shoppingCartService.AddToCartAsync(null, null, customProduct, 1, Session.ShoppingCartId);
                return Json(1);
            }
            return Json(0);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
