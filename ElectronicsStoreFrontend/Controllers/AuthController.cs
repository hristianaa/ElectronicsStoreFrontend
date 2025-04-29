using ElectronicsStoreFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ElectronicsStoreFrontend.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://onlineelectronicsstoresolution.onrender.com/api/")
            };
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var json = JsonSerializer.Serialize(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LoginResponseDto>(resultJson);

                TempData["Token"] = result.Token;
                TempData["Role"] = result.Role;  // ✅ Save user Role

                TempData["Message"] = "Login successful!";
                return RedirectToAction("Index", "Product");
            }

            TempData["Error"] = "Invalid email or password.";
            return View();
        }

    }
}
