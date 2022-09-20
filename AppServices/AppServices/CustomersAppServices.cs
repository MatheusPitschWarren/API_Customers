using DomainServices.Services;
using WebApiCustomers.Model;

namespace AppServices.AppServices
{
    public class CustomersAppServices : ICustomersAppServices
    {
        private readonly ICustomerServices _customerServices;

        public CustomersAppServices(ICustomerServices baseServices)
        {
            _customerServices = baseServices ?? throw new ArgumentNullException(nameof(baseServices));
        }

        public int Create(CustomersModel model)
        {
            return _customerServices.Create(model);
        }

        public int Delete(long id)
        {
            return _customerServices.Delete(id);
        }

        public List<CustomersModel> GetAll()
        {
            return _customerServices.GetAll();
        }

        public CustomersModel GetById(int id)
        {
            return _customerServices.GetById(id);
        }

        public int Update(CustomersModel model)
        {
            return _customerServices.Update(model);
        }
    }
}
