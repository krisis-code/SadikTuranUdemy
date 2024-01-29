using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Products =
        {
            "IPhone 13", "IPhone 14","IPhone 15"
        };

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
