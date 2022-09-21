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

    public int Create(Customer model)
    {
        model.Id = _customersList.LastOrDefault()?.Id + 1 ?? 1;

        if (!_customersList.Any())
        {
            _customersList.Add(model);
            return 0;
        }

        switch (checkDuplicate(model))
        {
            case 0:
                _customersList.Add(model);
                return 0;
            case 1:
                return 1;
            case 2:
                return 2;            
        }
        return 3;
    }

    public bool Update(Customer model)
    {
        var updateCustomer = GetById(model.Id);

        if (updateCustomer == null) return false;

        if (checkDuplicate(model) == 0)
        {
            var index = _customersList.FindIndex(customer => customer.Id == model.Id);

            if (index == -1) return false;

            _customersList[index] = model;
            return true;
        }
        return false;
    }

    public bool Delete(long id)
    {
        var deleteCustomer = GetById(id);

        if (deleteCustomer == null) return false;

        _customersList.Remove(deleteCustomer);
        return true;
    }

    private int checkDuplicate(Customer model)
    {
        if (_customersList.Any(customer => (customer.Cpf == model.Cpf) && customer.Id != model.Id)) return 1;
        if (_customersList.Any(customer => (customer.Email == model.Email) && customer.Id != model.Id)) return 2;
        return 0;
    }
}
