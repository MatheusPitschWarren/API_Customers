using DomainModel.Model;
using System.Collections.Generic;

namespace AppServices.Interfaces;

public interface ICustomersAppServices
{
    IEnumerable<CustomersModel> GetAll();
    CustomersModel GetById(long id);
    bool Create(CustomersModel model);
    bool Update(CustomersModel model);
    bool Delete(long id);
}
