using DomainModel.Model;

namespace AppServices.AppServices
{
    public interface IBaseAppServices
    {
        List<CustomersModel> GetAll();
        CustomersModel GetById(int id);
        int Create(CustomersModel model);
        int Update(CustomersModel model);
        int Delete(long id);

    }
}
