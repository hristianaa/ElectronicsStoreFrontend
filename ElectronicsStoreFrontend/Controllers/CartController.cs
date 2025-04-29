using ElectronicsStoreFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ElectronicsStoreFrontend.Controllers
{
    public class CartController : Controller
    {
        private readonly HttpClient _httpClient;

        public CartController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://onlineelectronicsstoresolution.onrender.com/api/")
            };
        }

        // ✅ Helper to attach token
        private void AddAuthorizationHeader()
        {
            if (TempData.ContainsKey("Token"))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", TempData["Token"].ToString());
            }

            // Persist TempData across actions
            TempData.Keep("Token");
            TempData.Keep("Role");
        }

        // ✅ GET /Cart
        public async Task<IActionResult> Index()
        {
            AddAuthorizationHeader();

            try
            {
                var cartItems = await _httpClient.GetFromJsonAsync<List<CartItemDto>>("cart");
                return View(cartItems ?? new List<CartItemDto>());
            }
            catch
            {
                TempData["Error"] = "Failed to load cart items.";
                return View(new List<CartItemDto>());
            }
        }

        // ✅ POST /Cart/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            AddAuthorizationHeader();

            var cartItem = new
            {
                ProductId = productId,
                Quantity = 1
            };

            var json = JsonSerializer.Serialize(cartItem);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("cart", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "✅ Product added to cart!";
            }
            else
            {
                TempData["Error"] = "❌ Failed to add product to cart.";
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
