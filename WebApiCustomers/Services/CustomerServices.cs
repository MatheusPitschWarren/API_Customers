using WebApiCustomers.Extension;
using WebApiCustomers.Model;

namespace WebApiCustomers.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly List<CustomersModel> _customersList = new();

        public List<CustomersModel> GetAll()
        {
            return _customersList;
        }

        public CustomersModel GetById(long id)
        {
            var customer = _customersList.FirstOrDefault(x => x.Id == id);

            return customer;
        }

        public bool Create(CustomersModel model)
        {
            model.Id = _customersList.LastOrDefault()?.Id + 1 ?? 1;

            if (!_customersList.Any())
            {
                _customersList.Add(model);
                return true;
            }
            if (!checkDuplicate(model))
            {
                _customersList.Add(model);
                return true;
            }
            return false;
        }

        public bool Update(CustomersModel model)
        {
            var updateModel = GetById(model.Id);

            if (updateModel == null)
                return false;

            if (checkDuplicate(model))
            {
                var index = _customersList.IndexOf(updateModel);

                _customersList[index] = model;
                return true;
            }
            return false;
        }

        public bool Delete(long id)
        {
            var customer = GetById(id);

            if (customer == null)
            {
                return false;
            }
            _customersList.Remove(customer);
            return true;
        }

        public bool checkDuplicate(CustomersModel model)
        {
            if (_customersList.Any(customer => customer.Cpf == model.Cpf || customer.Email == model.Email))
            {
                return true;
            }
            return false;
        }
    }
}
