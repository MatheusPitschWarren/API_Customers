using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.AppServices
{
    public interface IBaseAppServices
    {
        public int Create { get; set; }
        public int Update { get; set; }
        public int Delete { get; set; }
        public List<CustomersModel> GetAll{ get; set; }
    }
}
