using AppServices.Interfaces;
using DomainModel.Model;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.AppServices;

public class CustomersAppServices : ICustomersAppServices
{
    private readonly ICustomerServices _customerServices;

    public CustomersAppServices(ICustomerServices baseServices)
    {
        _customerServices = baseServices ?? throw new ArgumentNullException(nameof(baseServices));
    }

    public bool Create(Customer model)
    {
        return _customerServices.Create(model);
    }

    public bool Delete(long id)
    {
        return _customerServices.Delete(id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerServices.GetAll();
    }

    public Customer GetById(long id)
    {
        return _customerServices.GetById(id);
    }

    public bool Update(Customer model)
    {
        return _customerServices.Update(model);
    }        
}
