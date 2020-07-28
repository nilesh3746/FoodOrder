using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Models;
using FoodOrder.Persistence.Models;
using FoodOrder.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        // GET: Ingredient
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Message = TempData["Message"];
                var ingredients = _mapper.Map<List<IngredientViewModel>>(await _ingredientService.GetAllIngredientAsync());
                return View(ingredients);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Ingredient/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var ingredient = _mapper.Map<IngredientViewModel>(await _ingredientService.GetIngredientAsync(id));
            return View(ingredient);
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IngredientViewModel ingredientViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var newIngredientItem = await _ingredientService.AddIngredientAsync(_mapper.Map<Ingredient>(ingredientViewModel));
                    if (newIngredientItem != null)
                    {
                        TempData["Message"] = "Ingredient added successfully";
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

        // GET: Ingredient/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var ingredient = _mapper.Map<IngredientViewModel>(await _ingredientService.GetIngredientAsync(id));
            return View(ingredient);
        }

        // POST: Ingredient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IngredientViewModel ingredientViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var updateIngredient = await _ingredientService.UpdateIngredientAsync(_mapper.Map<Ingredient>(ingredientViewModel));
                    if (updateIngredient != null)
                    {
                        TempData["Message"] = "Ingredient updated successfully";
                        return RedirectToAction(nameof(Index));
                    }
                }
                var ingredient = _mapper.Map<IngredientViewModel>(await _ingredientService.GetIngredientAsync(ingredientViewModel.Id));
                return View(ingredient);
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredient/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ingredient = _mapper.Map<IngredientViewModel>(await _ingredientService.GetIngredientAsync(id));
            return View(ingredient);
        }

        // POST: Ingredient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(IngredientViewModel ingredientViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                var deletedIngredient = await _ingredientService.DeleteIngredientAsync(ingredientViewModel.Id);
                if (deletedIngredient != null)
                {
                    TempData["Message"] = "Ingredient deleted successfully";
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