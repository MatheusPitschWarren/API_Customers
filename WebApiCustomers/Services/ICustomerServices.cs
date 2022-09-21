using System.Reflection;
using WebApiCustomers.Model;

namespace WebApiCustomers.Services
{
    public interface ICustomerServices
    {
        bool Create(CustomersModel model);
        bool Delete(long id);
        List<CustomersModel> GetAll();
        CustomersModel GetById(long id);
        bool Update(CustomersModel model);
        bool checkDuplicate(CustomersModel model);               
    }
}