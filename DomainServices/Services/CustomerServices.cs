using DomainModel.Model;
using DomainServices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services;

public class CustomerServices : ICustomerServices
{
    private readonly List<CustomersModel> _customersList = new();

    public IEnumerable<CustomersModel> GetAll()
    {
        return _customersList;
    }

    public CustomersModel GetById(long id)
    {
        var customer = _customersList.FirstOrDefault(customer => customer.Id == id);

        return customer;
    }

    public int Create(CustomersModel model)
    {
        model.Id = _customersList.LastOrDefault()?.Id + 1 ?? 1;

        if (!_customersList.Any())
        {
            _customersList.Add(model);
            return 201;
        }
        if (!checkDuplicate(model))
        {
            _customersList.Add(model);
            return 201;
        }
        return 409;
    }

    public int Update(CustomersModel model)
    {
        var updateCustomer = GetById(model.Id);

        if (updateCustomer == null)
            return 404;

        if (!checkDuplicate(model))
        {
            var index = _customersList.IndexOf(updateCustomer);

            _customersList[index] = model;
            return 200;
        }
        return 404;
    }

    public int Delete(long id)
    {
        var deleteCustomer = GetById(id);

        if (deleteCustomer == null)
        {
            return 404;
        }
        _customersList.Remove(deleteCustomer);
        return 200;
    }

    public bool checkDuplicate(CustomersModel model)
    {
        if (_customersList.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
        {
            return true;
        }
        return false;
    }
}
