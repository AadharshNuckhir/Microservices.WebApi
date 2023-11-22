using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly List<Models.Customer> _customers = new List<Models.Customer>
    {
        new Models.Customer { Id = 1, Name = "John Doe", Email = "john@example.com" },
        new Models.Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
        // Add more dummy data as needed
    };

        [HttpGet]
        public ActionResult<IEnumerable<Models.Customer>> GetCustomers()
        {
            return Ok(_customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Customer> GetCustomerById(int id)
        {
            var customer = _customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound(); // Return 404 if customer with given id is not found
            }
            return Ok(customer);
        }
    }
}
