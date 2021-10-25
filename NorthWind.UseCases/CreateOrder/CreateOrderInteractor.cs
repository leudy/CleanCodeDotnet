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
    public class CreateOrderInteractor : AsyncRequestHandler<CreateOrderInputPort>
    {
        #region Repositories
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;
        #endregion
        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }
        protected async override Task Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order _newOrder = new Order()
            {
                CustomerId = request.RequestData.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.RequestData.ShipAddress,
                ShipCity = request.RequestData.ShipCity,
                ShipCountry = request.RequestData.ShipCountry,
                ShipPostCode = request.RequestData.ShipPostalCode,
                Discount = 10,
                ShippingType = Nortwind.Entities.Enums.ShippingType.Road,
                DiscountType = Nortwind.Entities.Enums.DiscountType.Percentage
            };
            orderRepository.Create(_newOrder);
            foreach (var item in request.RequestData.OrderDetails)
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
            request.OutPutPort.Handle(_newOrder.Id);

        }
    }
}
