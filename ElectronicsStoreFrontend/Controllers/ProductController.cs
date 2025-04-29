using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStoreFrontend.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
