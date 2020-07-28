using AspNetCore.ServiceRegistration.Dynamic.Attributes;
using FoodOrder.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories.Interfaces
{
    [ScopedService]
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }
}
