﻿using System.Reflection;
using WebApiCustomers.Model;

namespace AppServices.AppServices
{
    public interface ILorota
    {
        List<CustomersModel> GetAll();
        CustomersModel GetById(int id);
        int Create(CustomersModel model);
        int Update(CustomersModel model);
        int Delete(long id);
    }
}
