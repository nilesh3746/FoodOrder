using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Persistence.Repositories.Interfaces
{
    [ScopedService]
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
