﻿using Microsoft.AspNetCore.Mvc;
using TH01.Models.Interfaces;
using TH01.Models;

namespace coffeeshop.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private IShoppingCartRepository shoppingCartRepository;
        public OrdersController(IOrderRepository oderRepository,IShoppingCartRepository shoppingCartRepossitory)
        {
            this.orderRepository = oderRepository;
            this.shoppingCartRepository = shoppingCartRepossitory;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }
        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}
