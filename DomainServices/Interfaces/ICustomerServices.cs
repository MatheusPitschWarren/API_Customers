using DomainModel.Model;
using System.Collections.Generic;

namespace DomainServices.Interfaces;

public interface ICustomerServices
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    int Create(Customer model);
    bool Update(Customer model);
    bool Delete(long id);
}