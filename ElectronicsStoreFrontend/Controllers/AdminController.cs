using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStoreFrontend.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            if (TempData["Role"]?.ToString() != "Admin")
            {
                TempData["Error"] = "Access Denied. Admins only.";
                return RedirectToAction("Index", "Product");
            }

            return View();
        }

    }
}
