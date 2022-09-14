using DomainModel.Model;
using DomainServices.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.AppServices
{
    public class BaseAppServices : IBaseAppServices
    {
        private readonly IBaseServices _baseServices;

        public BaseAppServices(IBaseServices baseServices)
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
