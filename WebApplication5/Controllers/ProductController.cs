using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;


public class ProductController : Controller
{
    private readonly OrderService _orderService;

    public ProductController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult OrderForm(int quantity)
    {
        ViewBag.Quantity = quantity;
        return View();
    }

    [HttpPost]
    public IActionResult OrderForm(List<Product> products)
    {
        foreach (var product in products)
        {
            _orderService.AddProduct(product);
        }
        return RedirectToAction("Summary");
    }

    public IActionResult Summary()
    {
        var products = _orderService.GetProducts();
        ViewBag.TotalPrice = _orderService.GetTotalPrice();
        return View(products);
    }
}
