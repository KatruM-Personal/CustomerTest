using CustomerAPI.Repository;
using CustomerModels.Models;
using CustomerRepositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _repository.Get(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            _repository.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id) return BadRequest();
            var existing = _repository.Get(id);
            if (existing == null) return NotFound();
            _repository.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _repository.Get(id);
            if (customer == null) return NotFound();
            _repository.Delete(id);
            return NoContent();
        }
    }
}
