using Nortwind.Entities;
using Nortwind.Entities.Intefaces;

namespace NorthWind.Repositories.EFCore.Repositories
{
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
}
