using DomainModel.Model;
using System.Collections.Generic;

namespace AppServices.Interfaces;

public interface ICustomersAppServices
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    int Create(Customer model);
    bool Update(long id, Customer model);
    bool Delete(long id);
}
