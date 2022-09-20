using DomainModel.Model;
using System.Collections.Generic;

namespace DomainServices.Interfaces;

public interface ICustomerServices
{
    IEnumerable<CustomersModel> GetAll();
    CustomersModel GetById(long id);
    int Create(CustomersModel model);
    int Update(CustomersModel model);
    int Delete(long id);
}