using FoodOrder.Persistence.EntityFrameworkCore;
using FoodOrder.Persistence.Models;
using FoodOrder.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Persistence.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>,IOrderItemRepository
    {
        public OrderItemRepository(FoodDbContext context) : base(context)
        {

        }
    }
}
