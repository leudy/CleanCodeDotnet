using Nortwind.Entities;
using Nortwind.Entities.Intefaces;
using Nortwind.Entities.Specificactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthWindContext context;

        public OrderRepository(NorthWindContext context)
        {
            this.context = context;
        }
        public void Create(Order order)
        {
            context.Add(order);
        }

        public IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification)
        {
            var criteria = specification.Expression.Compile();
            return context.Orders.Where(criteria);  
        }
    }
}
