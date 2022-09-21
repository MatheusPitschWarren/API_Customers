using DomainModel.Model;
using System.Collections.Generic;

namespace DomainServices.Interfaces;

public interface ICustomerServices
{
    IEnumerable<CustomersModel> GetAll();
    CustomersModel GetById(long id);
    bool Create(CustomersModel model);
    bool Update(CustomersModel model);
    bool Delete(long id);
}