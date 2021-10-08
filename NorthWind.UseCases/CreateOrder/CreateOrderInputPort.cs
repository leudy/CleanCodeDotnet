using MediatR;
using NorthWind.UseCasesDtos.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : CreateOrderParams, IRequest<int>
    {
    }
}
