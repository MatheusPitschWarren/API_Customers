using AppServices.AppServices;
using DomainModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace AppServices.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IBaseAppServices _repository;

        public CustomersController(IBaseAppServices repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public CustomersModel GetById(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(CustomersModel model)
        {
            var response = _repository.Create(model);

            if (response == 201)
            {
                return Created("", response);
            }
            else if (response == 409)
            {
                return Conflict();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(CustomersModel model)
        {
            var codeHttp = _repository.Update(model);
            if (codeHttp == 200)
            {
                _repository.Update(model);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _repository.Delete(id);

            if (id == 200)
            {
                return Ok(_repository.Delete(id));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
