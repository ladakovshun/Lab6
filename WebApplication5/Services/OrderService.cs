using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class OrderService
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public decimal GetTotalPrice()
        {
            return _products.Sum(p => p.Price * p.Quantity);
        }
    }

}
