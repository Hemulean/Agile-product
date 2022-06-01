﻿using Microsoft.AspNetCore.Mvc;
using Webshop.Services;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly APIHandler _apiHandler;
        private readonly ProductHandler _productHandler;
        public ProductController(APIHandler apiHandler, ProductHandler productHandler)
        {
            _apiHandler = apiHandler;
            _productHandler = productHandler;
        }


        public async Task<IActionResult> Index()
        {
            var productsList = await _productHandler.GetMostPopularProducts(12);
            return View("Index", productsList);
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult MyAccount()
        {
            return View();
        }

       
        public async Task<IActionResult> GetApi()
        {
            var responseList = await _apiHandler.GetAllDataFromApi();

            return View("_Layout", responseList);
        }

        public async Task<IActionResult> GetProductsHighRating(int limit)
        {
            var productsList = await _productHandler.GetMostPopularProducts(limit);
            return View("Product", productsList);
        }


        public async Task<IActionResult> GetProductsByBrand(string brand, int limit)
        {
            var productsList = await _productHandler.GetProductsByBrand(brand, limit);

            return View("Product", productsList);
        }
        public async Task<IActionResult> GetProductsByType(string type, int limit)
        {
            //var productsList = await _productHandler.GetMostPopularProducts(12);
            return View("Index");
        }


        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var productsList = await _productHandler.GetProductsByCategory(category);

            return View("Product", productsList);
        }

        public async Task<IActionResult> GetProductById(int id)
        {
            var productById = await _productHandler.GetProductById(id);

            return View("Product", productById);
        }

    }
}
