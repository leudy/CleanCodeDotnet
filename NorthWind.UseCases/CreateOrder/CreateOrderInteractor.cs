using MediatR;
using Nortwind.Entities;
using Nortwind.Entities.Exceptions;
using Nortwind.Entities.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }
        //public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        //=> (orderDetailRepository, orderDetailRepository, unitOfWork) = (orderDetailRepository, orderDetailRepository, unitOfWork);






        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order _newOrder = new Order()
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostCode = request.ShipPostalCode,
                Discount = 10,
                ShippingType = Nortwind.Entities.Enums.ShippingType.Road,
                DiscountType = Nortwind.Entities.Enums.DiscountType.Percentage
            };
            orderRepository.Create(_newOrder);
            foreach (var item in request.OrderDetails)
            {
                var _newItem = new OrderDetail
                {
                    Order =  _newOrder,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };
                orderDetailRepository.Create(_newItem);
            }
            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw new GeneralException("Error al crear la orden", err.Message);
            }
            return _newOrder.Id;

        }
    }
}
