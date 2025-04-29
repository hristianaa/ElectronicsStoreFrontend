using ElectronicsStoreFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace ElectronicsStoreFrontend.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://onlineelectronicsstoresolution.onrender.com/api/")
            };
        }

        public async Task<IActionResult> Profile()
        {
            try
            {
                var orders = await _httpClient.GetFromJsonAsync<List<UserOrderDto>>("orders/user");
                return View(orders);
            }
            catch
            {
                TempData["Error"] = "Failed to load orders.";
                return View(new List<UserOrderDto>());
            }
        }
    }
}
