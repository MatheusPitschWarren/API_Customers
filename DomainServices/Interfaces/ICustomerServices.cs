using DomainModel.Model;
using System.Collections.Generic;

namespace DomainServices.Interfaces;

public interface ICustomerServices
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    long Create(Customer model);
    bool Update(Customer model);
    void Delete(long id);
}