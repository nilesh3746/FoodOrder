using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Models;
using FoodOrder.Models.ViewModels;
using FoodOrder.Persistence.Models;
using FoodOrder.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ComboMealController : Controller
    {
        private readonly IComboService _comboService;
        private readonly IComboProductService _comboProductService;
        private readonly IProductItemService _productItemService;
        private readonly IMapper _mapper;

        public ComboMealController(IComboService comboService, IComboProductService comboProductService, IProductItemService productItemService, IMapper mapper)
        {
            _comboService = comboService;
            _comboProductService = comboProductService;
            _productItemService = productItemService;
            _mapper = mapper;
        }
        // GET: ComboMeal
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Message = TempData["Message"];
                var combos = _mapper.Map<List<CombosViewModel>>(await _comboService.GetAllComboMealAsync());
                return View(combos);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: ComboMeal/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var combos = _mapper.Map<CombosViewModel>(await _comboService.GetComboMealAsync(id));
            return View(combos);
        }

        // GET: ComboMeal/Create
        public async Task<ActionResult> Create()
        {
            var comboProductViewModel = new ComboProductsViewModel()
            {
                ProductItems =  _mapper.Map<List<ProductItemViewModel>>(await _productItemService.GetAllProductItemAsync())
            };
            return View(comboProductViewModel);
        }

        // POST: ComboMeal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ComboProductsViewModel comboProductsViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    var comboMeal = await _comboService.AddComboMealAsync(_mapper.Map<ComboMeal>(comboProductsViewModel.ComboMeal));

                    var comboProducts = new List<ComboProductViewModel>();

                    foreach (var productItemId in comboProductsViewModel.ProductItemIds)
                    {
                        comboProducts.Add(new ComboProductViewModel() { ComboId = comboMeal.Id, ProductItemId = productItemId });
                    }
                    await _comboProductService.AddComboProductRangeAsync(_mapper.Map<List<ComboProduct>>(comboProducts));
                    return RedirectToAction(nameof(Index));
                }
                var comboProductViewModel = new ComboProductsViewModel()
                {
                    ProductItems = _mapper.Map<List<ProductItemViewModel>>(await _productItemService.GetAllProductItemAsync())
                };
                return View(comboProductViewModel);
            }
            catch(Exception)
            {
                return View();
            }
        }

        #region Edit Operations
        // GET: ComboMeal/Edit/5
        //public async Task<ActionResult> Edit(int id)
        //{
        //    var combos = _mapper.Map<CombosViewModel>(await _comboService.GetComboMealAsync(id));
        //    foreach (var product in combos.ComboProducts)
        //    {

        //    }
        //    return View(combos);
        //}

        //// POST: ComboMeal/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion

        // GET: ComboMeal/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var combos = _mapper.Map<CombosViewModel>(await _comboService.GetComboMealAsync(id));
            return View(combos);
        }

        // POST: ComboMeal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(ComboMealViewModel comboMealViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                var deletedCombos = await _comboService.DeleteComboMealAsync(comboMealViewModel.Id);
                if (deletedCombos != null)
                {
                    TempData["Message"] = "Combo Meal deleted successfully";
                    return RedirectToAction(nameof(Index));
                }
                var combos = _mapper.Map<CombosViewModel>(await _comboService.GetComboMealAsync(comboMealViewModel.Id));
                return View(combos);
            }
            catch(Exception)
            {
                return View();
            }
        }

    }
}