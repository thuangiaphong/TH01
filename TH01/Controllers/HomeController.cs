﻿using Microsoft.AspNetCore.Mvc;
using TH01.Models.Interfaces;

namespace TH01.Controllers
{
	public class HomeController : Controller
	{
		private IProductRepository productRepository;

		public HomeController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}
		public IActionResult Index()
		{
			return View(productRepository.GetTrendingProducts());
		}
	}
}
