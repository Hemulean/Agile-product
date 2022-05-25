using Microsoft.AspNetCore.Mvc;
using Webshop.Services;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly APIHandler _apiHandler;
        public ProductController(APIHandler apiHandler)
        {
            _apiHandler = apiHandler;
        }


        public async Task<IActionResult> GetApi()
        {
            var responseList = _apiHandler.GetAllDataFromApi();

            return View("_Layout");
        }
    }
}
