using WebApiCustomers.Model;

namespace WebApiCustomers.Services
{
    public interface ICustomerServices
    {
        int Create(CustomersModel model);
        int Delete(long id);
        List<CustomersModel> GetAll();
        CustomersModel GetById(long id);
        int Update(CustomersModel model);
    }
}