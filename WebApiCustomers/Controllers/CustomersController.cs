
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApiCustomers.Model;
using WebApiCustomers.Repository;

namespace WebApiCustomers.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IBaseRepository _repository;

        public CustomersController(IBaseRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _repository.GetById(id);

            if (response != null)
            {
                return Ok(response);
            }
            return NotFound($"Id not found: {id}");
        }

        [HttpPost]
        public IActionResult Post(CustomersModel model)
        {
            var response = _repository.Create(model);

            if (response == 201)
            {
                return Created("", response);
            }
            return BadRequest("There is already a customer with this CPF and Email");
        }

        [HttpPut]
        public IActionResult Put(CustomersModel model)
        {
            var response = _repository.Update(model);

            if (response == 200)
            {
                _repository.Update(model);
                return Ok($"customer id was successfully changed: {model.Id}");
            }
            return NotFound($"A customer with that id was not found: {model.Id}");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _repository.Delete(id);

            if (response == 200)
            {
                return Ok($"The customer with this Id has been deleted: {id}");
            }
            return NotFound($"A customer with that id was not found: {id}");
        }
    }
}
