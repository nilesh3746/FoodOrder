using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Models;
using FoodOrder.Persistence.Models;
using FoodOrder.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductItemService _productItemService;
        private readonly IComboService _comboService;
        private readonly IComboProductService _comboProductService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IProductItemService productItemService, IComboService comboService, IComboProductService comboProductService, IMapper mapper)
        {
            _productService = productService;
            _productItemService = productItemService;
            _comboService = comboService;
            _comboProductService = comboProductService;
            _mapper = mapper;
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Message = TempData["Message"];
                var produts = _mapper.Map<List<ProductViewModel>>(await _productService.GetAllProductAsync());
                return View(produts);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productService.GetProductAsync(id));
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var newProduct = await _productService.AddProductAsync(_mapper.Map<Product>(product));
                    if (newProduct != null)
                    {
                        TempData["Message"] = "Product added successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productService.GetProductAsync(id));
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductViewModel product)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var updatedProduct = await _productService.UpdateProductAsync(_mapper.Map<Product>(product));
                    if (updatedProduct != null)
                    {
                        TempData["Message"] = "Product updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productService.GetProductAsync(id));
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProductViewModel product)
        {
            try
            {
                // TODO: Add delete logic here
                var productItems = await _productItemService.GetAllByProductIdAsync(product.Id);
                foreach (var item in productItems)
                {
                    var combos = await _comboProductService.GetAllByProductItemIdAsync(item.Id);
                    foreach (var combo in combos)
                    {
                        if (await _comboService.GetComboMealAsync(combo.ComboId) != null)
                        {
                            await _comboService.DeleteComboMealAsync(combo.ComboId);
                        }
                    }
                }
                var deletedProduct = await _productService.DeleteProductAsync(product.Id);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}