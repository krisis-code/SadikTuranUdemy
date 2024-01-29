using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public static List<Product>? _products;

        public ProductsController()
        {
            _products = new List<Product>
            {
                 new() { ProductId = 0, ProductName = "IPhone 12", Price = 50000, IsActive = true },
                 new()  { ProductId = 1, ProductName = "IPhone 13", Price = 60000, IsActive = true },
                 new()  { ProductId = 2, ProductName = "IPhone 14", Price = 70000, IsActive = true },
                 new()  { ProductId = 3, ProductName = "IPhone 15", Price = 80000, IsActive = true }
            };
        }
           
        [HttpGet]
        public string[] GetProducts()
        {
            return Products;
        }

        [HttpGet("id")]
        public string GetProduct(int id)
        {
            return Products[id];
        }
    }
}
