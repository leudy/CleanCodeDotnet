using MediatR;
using NorthWind.UseCasesDtos.CreateOrder;
using NorthWind.UseCases.Common.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int> 
    {
        public CreateOrderParams RequestData { get; }
        public IOutputPort<int> OutPutPort { get; }
        public CreateOrderInputPort(CreateOrderParams OrderData, IOutputPort<int> outputport)
            => (RequestData, OutPutPort) = (OrderData, outputport);
        
    }
}
