using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly ProductsContext _context;
        public ProductsController(ProductsContext context)
        {
           _context = context;
        }
           
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();   

            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int? id)
        {

            if (id == null)
            {
               return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync( i => i.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _context.Products.Add(entity);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = entity.ProductId } , entity);
        }
    }
}
