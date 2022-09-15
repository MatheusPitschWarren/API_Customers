using DomainModel.Model;
using WebApiCustomers.Model;

namespace DomainServices.BaseServices
{
    public interface IBaseServices
    {
        List<CustomersModel> GetAll();
        CustomersModel GetById(long id);
        int Create(CustomersModel model);
        int Update(CustomersModel model);
        int Delete(long id);
    }
}