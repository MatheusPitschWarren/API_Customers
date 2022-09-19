using DomainServices.BaseServices;
using WebApiCustomers.Model;

namespace AppServices.AppServices
{
    public class Lorota : ILorota
    {
        private readonly ICustomerServices _baseServices;

        public Lorota(ICustomerServices baseServices)
        {
            _baseServices = baseServices ?? throw new ArgumentNullException(nameof(baseServices));
        }

        public int Create(CustomersModel model)
        {
            return _baseServices.Create(model);
        }

        public int Delete(long id)
        {
            return _baseServices.Delete(id);
        }

        public List<CustomersModel> GetAll()
        {
            return _baseServices.GetAll();
        }

        public CustomersModel GetById(int id)
        {
            return _baseServices.GetById(id);
        }

        public int Update(CustomersModel model)
        {
            return _baseServices.Update(model);
        }
    }
}
