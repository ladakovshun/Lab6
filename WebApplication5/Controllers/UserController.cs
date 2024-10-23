using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        private readonly OrderService _orderService;

        public UserController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Age >= 16)
            {
                return RedirectToAction("ConfirmOrder");
            }
            else
            {
                ModelState.AddModelError("", "You must be at least 16 years old.");
                return View();
            }
        }

        [HttpGet]
        public IActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmOrder(int quantity)
        {
            return RedirectToAction("OrderForm", "Product", new { quantity });
        }
    }
}
