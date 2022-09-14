using DomainModel.Model;

namespace DomainServices.BaseServices
{
    public interface IBaseServices
    {
        int Create(CustomersModel model);
        int Delete(long id);
        List<CustomersModel> GetAll();
        CustomersModel GetById(long id);
        int Update(CustomersModel model);
    }
}