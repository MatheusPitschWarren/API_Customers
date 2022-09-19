using DomainModel.Model;
using WebApiCustomers.Model;

namespace DomainServices.Services
{
    public interface ICustomerServices
    {
        List<CustomersModel> GetAll();
        CustomersModel GetById(long id);
        int Create(CustomersModel model);
        int Update(CustomersModel model);
        int Delete(long id);
    }
}