using Microsoft.AspNetCore.Mvc;
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
            return View("Index",productsList);
        }
        public async Task<IActionResult> GetApi()
        {
            var responseList = await _apiHandler.GetAllDataFromApi();

            return View("_Layout",responseList);

        }


        public async Task<IActionResult> GetProductsHighRating()
        {
            //var productsList = await _productHandler.GetMostPopularProducts(12);
            return View("Index");
        }

    }
}
