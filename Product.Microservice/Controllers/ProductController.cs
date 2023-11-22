using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly List<Models.Product> _products = new List<Models.Product>
    {
        new Models.Product { Id = 1, Name = "Product A", Price = 19.99M },
        new Models.Product { Id = 2, Name = "Product B", Price = 29.99M }
        // Add more dummy data as needed
    };

        [HttpGet]
        public ActionResult<IEnumerable<Models.Product>> GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Product> GetProductById(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product with given id is not found
            }
            return Ok(product);
        }
    }
}
