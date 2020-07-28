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
    public class ProductItemController : Controller
    {
        private readonly IProductItemService _productItemService;
        private readonly IProductService _productService;
        private readonly IComboService _comboService;
        private readonly IComboProductService _comboProductService;
        private readonly IMapper _mapper;

        public ProductItemController(IProductItemService productItemService, IProductService productService, IComboService comboService, IComboProductService comboProductService, IMapper mapper)
        {
            _productItemService = productItemService;
            _productService = productService;
            _comboService = comboService;
            _comboProductService = comboProductService;
            _mapper = mapper;
        }

        // GET: ProductItem
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Message = TempData["Message"];
                var productItems = _mapper.Map<List<ProductItemViewModel>>(await _productItemService.GetAllProductItemAsync());
                return View(productItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: ProductItem/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var productItemViewModel = _mapper.Map<ProductItemViewModel>(await _productItemService.GetProductItemAsync(id));
            return View(productItemViewModel);
        }

        // GET: ProductItem/Create
        public async Task<ActionResult> Create()
        {
            ProductItemsViewModel productItemsViewModel = new ProductItemsViewModel
            {
                ProductViewModels = _mapper.Map<List<ProductViewModel>>(await _productService.GetAllProductAsync())
            };
            return View(productItemsViewModel);
        }

        // POST: ProductItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductItemsViewModel productItem)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var newProductItem = await _productItemService.AddProductItemAsync(_mapper.Map<ProductItem>(productItem.ProductItemViewModel));
                    if (newProductItem != null)
                    {
                        TempData["Message"] = "Product Item added successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                ProductItemsViewModel productItemsViewModel = new ProductItemsViewModel
                {
                    ProductViewModels = _mapper.Map<List<ProductViewModel>>(await _productService.GetAllProductAsync())
                };
                return View(productItemsViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductItem/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ProductItemsViewModel productItemsViewModel = new ProductItemsViewModel
            {
                ProductItemViewModel = _mapper.Map<ProductItemViewModel>(await _productItemService.GetProductItemAsync(id)),
                ProductViewModels = _mapper.Map<List<ProductViewModel>>(await _productService.GetAllProductAsync())
            };
            return View(productItemsViewModel);
        }

        // POST: ProductItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductItemsViewModel productItem)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var updateProductItem = await _productItemService.UpdateProductItemAsync(_mapper.Map<ProductItem>(productItem.ProductItemViewModel));
                    if (updateProductItem != null)
                    {
                        TempData["Message"] = "Product Item updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                ProductItemsViewModel productItemsViewModel = new ProductItemsViewModel
                {
                    ProductItemViewModel = _mapper.Map<ProductItemViewModel>(await _productItemService.GetProductItemAsync(productItem.ProductItemViewModel.Id)),
                    ProductViewModels = _mapper.Map<List<ProductViewModel>>(await _productService.GetAllProductAsync())
                };
                return View(productItemsViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductItem/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var productItem = _mapper.Map<ProductItemViewModel>(await _productItemService.GetProductItemAsync(id));
            return View(productItem);
        }

        // POST: ProductItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProductItemViewModel productItem)
        {
            try
            {
                // TODO: Add delete logic here
                var combos = await _comboProductService.GetAllByProductItemIdAsync(productItem.Id);
                foreach (var combo in combos)
                {
                    if (await _comboService.GetComboMealAsync(combo.ComboId) != null)
                    {
                        await _comboService.DeleteComboMealAsync(combo.ComboId);
                    }
                }
                var deletedProduct = await _productItemService.DeleteProductItemAsync(productItem.Id);
                if (deletedProduct != null)
                {
                    TempData["Message"] = "Product deleted successfully";
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}