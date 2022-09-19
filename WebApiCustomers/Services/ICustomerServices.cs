using System.Reflection;
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

        private bool checkDuplicate(List<CustomersModel> _customersList, CustomersModel model)
        {
            if (_customersList.Any(customer => customer.Cpf != model.Cpf || customer.Email != model.Email))
            {
                return false;
            }
            return true;
        }
    }
}