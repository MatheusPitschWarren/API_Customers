using WebApiCustomers.Model;

namespace WebApiCustomers.Repository
{
    public interface IBaseRepository
    {

        int Create(CustomersModel model);
        int Delete(int id);
        List<CustomersModel> GetAll();
        CustomersModel GetById(int id);
        int Update(CustomersModel model);
    }
}