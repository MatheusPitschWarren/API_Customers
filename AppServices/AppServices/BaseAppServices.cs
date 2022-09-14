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

        public int Create { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Update { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Delete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<CustomersModel> GetAll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
