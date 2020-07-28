using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using FoodOrder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
           _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _customerRepository.AddAsync(customer);
        }
    }
}
