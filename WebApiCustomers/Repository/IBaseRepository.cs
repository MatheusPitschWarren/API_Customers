using WebApiCustomers.Model;

namespace WebApiCustomers.Repository
{
    public interface IBaseRepository
    {

        int Create(CustomersModel model);
        int Delete(long id);
        List<CustomersModel> GetAll();
        CustomersModel GetById(long id);
        int Update(CustomersModel model);
    }
}