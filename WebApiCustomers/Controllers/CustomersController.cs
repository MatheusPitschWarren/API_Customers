using AppServices.Interfaces;
using DomainModel.Model;
using DomainServices.Expections;
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
        try
        {
            var response = _customerAppServices.GetById(id);
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(Customer model)
    {
        try
        {
            var response = _customerAppServices.Create(model);
            return Created("", response);
        }
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(long id, Customer model)
    {
        try
        {
            model.Id = id;
            var response = _customerAppServices.Update(model);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(long id)
    {
        try
        {
            _customerAppServices.Delete(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}