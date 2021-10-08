using Nortwind.Entities.Specificactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Entities.Intefaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification);

    }
    public interface IOrderDetailRepository
    {
        void Create(OrderDetail orderDetail);
    }
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
