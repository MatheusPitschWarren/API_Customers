using AppServices.Interfaces;
using DomainModel.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class CustomersController : Controller
{
    private readonly ICustomersAppServices _customerAppServices;

    public CustomersController(ICustomersAppServices customerAppServices)
    {
        _customerAppServices = customerAppServices ?? throw new ArgumentNullException(nameof(customerAppServices));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _customerAppServices.GetAll();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        var response = _customerAppServices.GetById(id);

        if (response == null) return NotFound($"Id not found: {id}");
        
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Post(Customer model)
    {
        var response = _customerAppServices.Create(model);

        switch (response)
        {
            case 0:
                return Created("", $"Customer created with Id: {model.Id}");
            case 1:
                return BadRequest($"There is already a customer with this CPF: {model.Cpf}.");
            case 2:
                return BadRequest($"There is already a customer with this Email: {model.Email}");
            default:
                return BadRequest(response);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, Customer model)
    {
        var response = _customerAppServices.Update(id, model);

        if (response)
        {
            _customerAppServices.Update(id,model);
            return Ok($"customer id was successfully changed: {model.Id}");
        }
        return NotFound($"A customer with that id was not found: {model.Id}");
    }

    [HttpDelete]
    public IActionResult Delete(long id)
    {
        var response = _customerAppServices.Delete(id);

        if (response) return Ok($"The customer with this Id has been deleted: {id}");
        
        return NotFound($"A customer with that id was not found: {id}");
    }
}
