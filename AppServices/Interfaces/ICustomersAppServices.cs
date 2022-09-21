﻿using DomainModel.Model;
using System.Collections.Generic;

namespace AppServices.Interfaces;

public interface ICustomersAppServices
{
    IEnumerable<Customer> GetAll();
    Customer GetById(long id);
    bool Create(Customer model);
    bool Update(Customer model);
    bool Delete(long id);
}
