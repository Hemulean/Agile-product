using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
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
    }
}
