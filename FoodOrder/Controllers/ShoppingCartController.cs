using AutoMapper;
using FoodOrder.Models;
using FoodOrder.Models.ViewModels;
using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IProductItemService _productItemService;
        private readonly IComboService _comboService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartSession Session { get; }

        public ShoppingCartController(IProductItemService productItemService, IComboService comboService, IShoppingCartService shoppingCartService, IMapper mapper, ShoppingCartSession session)
        {
            _productItemService = productItemService;
            _comboService = comboService;
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            Session = session;
        }

        public ShoppingCartViewModel GetCart()
        {
            return _mapper.Map<ShoppingCartViewModel>(_shoppingCartService.GetCartAsync(Session.ShoppingCartId));
        }

        public async Task<ViewResult> Index()
        {
            var items = await _shoppingCartService.GetShoppingCartItems(Session.ShoppingCartId);
            var shoppingCart = new ShoppingCartViewModel()
            {
                ShoppingCartItems = _mapper.Map<List<ShoppingCartItemViewModel>>(items)
            };

            var shoppingCartViewModel = new ShoppingViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = _shoppingCartService.GetShoppingCartTotal(Session.ShoppingCartId)
            };
            return View(shoppingCartViewModel);
        }

        //[Authorize]
        public async Task<RedirectToActionResult> AddToShoppingCart(List<SelectProductViewModel> productItems, List<SelectComboProductViewModel> comboMeals)
        {
            if (productItems.Any())
            {
                foreach (var item in productItems)
                {
                    var prodItem = await _productItemService.GetProductItemAsync(item.Id);
                    await _shoppingCartService.AddToCartAsync(prodItem, null, null, item.Quantity, Session.ShoppingCartId);
                }
            }

            if (comboMeals.Any())
            {
                foreach (var combo in comboMeals)
                {
                    var comboMeal = await _comboService.GetAsync(combo.Id);
                    await _shoppingCartService.AddToCartAsync(null, comboMeal, null, combo.Quantity, Session.ShoppingCartId);
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var shoppingCartItem =  await _shoppingCartService.GetAsync(id);
            if (shoppingCartItem != null)
            {
                await _shoppingCartService.RemoveFromCart(shoppingCartItem.ShoppingCartItemId);
            }
            return RedirectToAction("Index");
        }

    }
}
