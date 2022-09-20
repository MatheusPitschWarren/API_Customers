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

    public int Create(CustomersModel model)
    {
        return _customerServices.Create(model);
    }

    public int Delete(long id)
    {
        return _customerServices.Delete(id);
    }

    public IEnumerable<CustomersModel> GetAll()
    {
        return _customerServices.GetAll();
    }

    public CustomersModel GetById(long id)
    {
        return _customerServices.GetById(id);
    }

    public int Update(CustomersModel model)
    {
        return _customerServices.Update(model);
    }        
}
