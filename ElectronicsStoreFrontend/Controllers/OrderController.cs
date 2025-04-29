using ElectronicsStoreFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStoreFrontend.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Confirmation()
        {
            var order = new OrderConfirmationDto
            {
                OrderId = new Random().Next(1000, 9999),
                TotalAmount = 199.99m,
                CreatedAt = DateTime.Now
            };

            return View(order);
        }
    }
}
