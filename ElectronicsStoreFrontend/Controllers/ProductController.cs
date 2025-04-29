using ElectronicsStoreFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace ElectronicsStoreFrontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://onlineelectronicsstoresolution.onrender.com/api/")
            };
        }

        public async Task<IActionResult> Index()
        {
            var products = await _httpClient.GetFromJsonAsync<List<ProductDto>>("products");
            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<ProductDto>($"products/{id}");
            return View(product);
        }

    }
}
