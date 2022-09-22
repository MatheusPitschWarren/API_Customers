using DomainModel.Model;
using DomainServices.Expections;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services;

public class CustomerServices : ICustomerServices
{
    private readonly List<Customer> _customersList = new();

    public IEnumerable<Customer> GetAll()
    {
        return _customersList;
    }

    public Customer GetById(long id)
    {
        var customer = _customersList.FirstOrDefault(customer => customer.Id == id);

        if (customer == null) throw new NotFoundException($"Custmer with Id: {id} not found");

        return customer;
    }

    public long Create(Customer model)
    {
        model.Id = _customersList.LastOrDefault()?.Id + 1 ?? 1;

        CheckIfUserIsValid(model);
        _customersList.Add(model);

        return model.Id;
    }

    public bool Update(Customer model)
    {
        var updateCustomer = GetById(model.Id);

        if (updateCustomer == null) return false;

        CheckIfUserIsValid(model);

        var index = _customersList.FindIndex(customer => customer.Id == model.Id);

        if (index == -1) throw new NotFoundException($"A customer with that id was not found: {model.Id}");

        _customersList[index] = model;
        return true;
    }

    public void Delete(long id)
    {
        var deleteCustomer = GetById(id);

        _customersList.Remove(deleteCustomer);        
    }

    private void CheckIfUserIsValid(Customer model)
    {
        if (_customersList.Any(customer => (customer.Cpf == model.Cpf) && customer.Id != model.Id))
            throw new NotFoundException($"There is already a customer with this CPF: {model.Cpf}.");

        if(_customersList.Any(customer => (customer.Email == model.Email) && customer.Id != model.Id))
            throw new NotFoundException($"There is already a customer with this Email: {model.Email}");        
    }
}