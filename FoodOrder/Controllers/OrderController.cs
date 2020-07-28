using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Models;
using FoodOrder.Persistence.Models;
using FoodOrder.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public ShoppingCartSession Session { get; }

        public OrderController(IOrderService orderService, IOrderItemService orderItemService, IShoppingCartService shoppingCartService, IMapper mapper, ShoppingCartSession session, ICustomerService customerService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            Session = session;
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var items = await _shoppingCartService.GetShoppingCartItems(Session.ShoppingCartId);
                var customer = await _customerService.AddCustomerAsync(_mapper.Map<Customer>(orderViewModel));
                
                var order = new Order()
                {
                    Amount = _shoppingCartService.GetShoppingCartTotal(Session.ShoppingCartId),
                    CustomerId = customer.Id,
                    Date = DateTime.Now
                };
                await _orderService.AddOrderAsync(order);

                foreach (var item in items)
                {
                    var orderItem = new OrderItem()
                    {
                        OrderId = order.Id,
                        ProductItemId = item.ProductItemId,
                        ComboMealId = item.ComboMealId,
                        CustomizeProductId = null,
                        Quantity = item.Quantity
                    };
                    await _orderItemService.AddOrderItemAsync(orderItem);
                }

                await _shoppingCartService.ClearCart(Session.ShoppingCartId);
                return RedirectToAction("OrderComplete");
            }
            return View(orderViewModel);
        }

        public IActionResult OrderComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }
    }
}