using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly FoodDbContext context;

        public CustomerRepository(FoodDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
