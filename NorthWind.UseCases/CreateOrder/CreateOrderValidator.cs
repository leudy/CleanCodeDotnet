using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty().WithMessage("Debe espeficiar un clienteid");
            RuleFor(c => c.RequestData.ShipAddress).NotEmpty().WithMessage("Debe espeficiar una direccion");
            RuleFor(c => c.RequestData.ShipCity).NotEmpty().MinimumLength(3).WithMessage("Debe proporcionar al menos 3 caracteres del nombre de la ciudad");
            RuleFor(c => c.RequestData.ShipCountry).NotEmpty().MinimumLength(3).WithMessage("Debe proporcionar al menos 3 caracteres del nombre de la Pais");
            RuleFor(o => o.RequestData.OrderDetails)
                .Must(o => o != null && o.Any()).WithMessage("Deben especificarse los productos de la orden");
        }

    }
}
