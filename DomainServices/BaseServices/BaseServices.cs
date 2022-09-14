
using FluentValidation;
using FluentValidation.Results;
using DomainModel.Model;

namespace DomainServices.BaseServices
{
    public class BaseServices : IBaseServices
    {
        private readonly List<CustomersModel> _customersList = new();

        public virtual List<CustomersModel> GetAll()
        {
            return _customersList;
        }

        public virtual CustomersModel GetById(long id)
        {
            return _customersList.Where(x => x.Id == id).FirstOrDefault();
        }

        public virtual int Create(CustomersModel model)
        {
            model.Cpf = model.Cpf.Trim().Replace(".", "").Replace("-", "");
            model.Id = _customersList.Count + 1;

            foreach (CustomersModel infoCustomer in _customersList)
            {
                if (model.Cpf != infoCustomer.Cpf && model.Email != infoCustomer.Email)
                {
                    _customersList.Add(model);
                    return 201;
                }
            }
            return 409;
        }

        public virtual int Update(CustomersModel model)
        {
            var updateModel = GetById(model.Id);

            model.Cpf = model.Cpf.Trim().Replace(".", "").Replace("-", "");

            if (updateModel == null)
                return 404;

            var customer = _customersList.Where(customer => customer.Cpf == model.Cpf || customer.Email == model.Email).FirstOrDefault();

            if (customer != null)
            {
                updateModel.Id = customer.Id;

                var index = _customersList.IndexOf(customer);

                _customersList[index] = model;

                return 200;
            }

            return 404;
        }

        public virtual int Delete(long id)
        {
            var customer = GetById(id);

            if (customer != null)
            {
                _customersList.Remove(customer);
                return 200;
            }
            else
            {
                return 404;
            }
        }
    }
}
