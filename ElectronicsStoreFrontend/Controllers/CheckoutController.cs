using ElectronicsStoreFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ElectronicsStoreFrontend.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly HttpClient _httpClient;

        public CheckoutController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppProps.BASE_URL)
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckoutDto checkout)
        {
            var json = JsonSerializer.Serialize(checkout);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("orders", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "✅ Order placed successfully!";
                return RedirectToAction("Confirmation", "Order");

            }

            TempData["Error"] = "❌ Failed to place order. Try again.";
            return View();
        }
    }
}
