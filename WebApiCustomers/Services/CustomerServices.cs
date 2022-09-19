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

        public int Create(CustomersModel model)
        {
            model.Id = _customersList.LastOrDefault()?.Id + 1 ?? 1;

            if (!_customersList.Any())
            {
                _customersList.Add(model);
                return 201;
            }
            if (!checkDuplicate(model))
            {
                _customersList.Add(model);
                return 201;
            }
            return 409;
        }

        public int Update(CustomersModel model)
        {
            var updateModel = GetById(model.Id);

            if (updateModel == null)
                return 404;

            if (!checkDuplicate(model))
            {
                var index = _customersList.IndexOf(updateModel);

                _customersList[index] = model;
                return 200;
            }
            return 404;
        }

        public int Delete(long id)
        {
            var customer = GetById(id);

            if (customer == null)
            {
                return 404;
            }
            _customersList.Remove(customer);
            return 200;
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
