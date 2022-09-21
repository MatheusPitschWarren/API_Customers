using DomainModel.Model;
using DomainServices.Interfaces;
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

        return customer;
    }

    public bool Create(Customer model)
    {
        model.Id = _customersList.LastOrDefault()?.Id + 1 ?? 1;

        if (!_customersList.Any())
        {
            _customersList.Add(model);
            return true;
        }
        if (!checkDuplicate(model))
        {
            _customersList.Add(model);
            return true;
        }
        return false;
    }

    public bool Update(Customer model)
    {
        var updateCustomer = GetById(model.Id);

        if (updateCustomer == null)
            return false;

        if (!checkDuplicate(model))
        {
            var index = _customersList.IndexOf(updateCustomer);

            _customersList[index] = model;
            return true;
        }
        return false;
    }

    public bool Delete(long id)
    {
        var deleteCustomer = GetById(id);

        if (deleteCustomer == null)
        {
            return false;
        }
        _customersList.Remove(deleteCustomer);
        return true;
    }

    public bool checkDuplicate(Customer model)
    {
        if (_customersList.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
        {
            return true;
        }
        return false;
    }
}
