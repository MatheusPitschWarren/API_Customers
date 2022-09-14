using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCustomers.Model;
using WebApiCustomers.Validator;

namespace WebApiCustomers.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly List<CustomersModel> _customersList = new();

        public List<CustomersModel> GetAll()
        {
            return _customersList;
        }

        public CustomersModel GetById(long id)
        {
            var customer = _customersList.Where(x => x.Id == id).FirstOrDefault();

            return customer;
        }

        public int Create(CustomersModel model)
        {
            model.Cpf = model.Cpf.Trim().Replace(".", "").Replace("-", "");
            model.Id = _customersList.Count + 1;

            CustomerValidator validator = new();
            ValidationResult result = validator.Validate(model);

            if (result.IsValid)
            {
                if (!_customersList.Any())
                {
                    _customersList.Add(model);
                    return 201;
                }

                foreach (CustomersModel infoCustomer in _customersList)
                {
                    if (model.Cpf != infoCustomer.Cpf && model.Email != infoCustomer.Email)
                    {
                        _customersList.Add(model);
                        return 201;
                    }
                    return 409;
                }
            }
            return 400;
        }

        public int Update(CustomersModel model)
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

        public int Delete(long id)
        {
            var customer = GetById(id);

            if (customer != null)
            {
                _customersList.Remove(customer);
                return 200;
            }
            return 404;
        }
    }
}
