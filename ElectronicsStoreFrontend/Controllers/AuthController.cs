using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStoreFrontend.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
