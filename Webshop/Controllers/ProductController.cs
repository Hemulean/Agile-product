using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
