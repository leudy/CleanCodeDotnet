using Nortwind.Entities.Specificactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nortwind.Entities.Intefaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrderBySpecification(Specification<Order> specification);

    }
}
