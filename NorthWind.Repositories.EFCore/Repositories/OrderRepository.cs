using Nortwind.Entities;
using Nortwind.Entities.Intefaces;
using Nortwind.Entities.Specificactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly NorthWindContext context;

        public OrderDetailRepository(NorthWindContext context)
        {
            this.context = context;
        }
        public void Create(OrderDetail orderDetail)
        {
            context.Add(orderDetail);
        }
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthWindContext context;

        public UnitOfWork(NorthWindContext context)
        {
            this.context = context;
        }
        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync(); 
        }
    }
}
