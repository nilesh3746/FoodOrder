using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services.Interfaces
{
    [ScopedService]
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}
