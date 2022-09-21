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

        if (response != null)
        {
            return Ok(response);
        }
        return NotFound($"Id not found: {id}");
    }

    [HttpPost]
    public IActionResult Post(Customer model)
    {
        var response = _customerAppServices.Create(model);

        if (response)
        {
            return Created("", $"Customer created with Id: {model.Id}");
        }
        return BadRequest("There is already a customer with this CPF and Email");
    }

    [HttpPut]
    public IActionResult Put(Customer model)
    {
        var response = _customerAppServices.Update(model);

        if (response)
        {
            _customerAppServices.Update(model);
            return Ok($"customer id was successfully changed: {model.Id}");
        }
        return NotFound($"A customer with that id was not found: {model.Id}");
    }

    [HttpDelete]
    public IActionResult Delete(long id)
    {
        var response = _customerAppServices.Delete(id);

        if (response)
        {
            return Ok($"The customer with this Id has been deleted: {id}");
        }
        return NotFound($"A customer with that id was not found: {id}");
    }
}
