using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Nortwind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
namespace NorthWind.WebExceptionsPresenter
{
    public class ValidationExceptionHanlder : ExceptionHanlderBase, IExceptionHandler
    {
        public Task handler(ExceptionContext context)
        {
            var _Exception = context.Exception as ValidationException;
            StringBuilder erroBuilder = new StringBuilder();
            foreach (var item in _Exception.Errors)
            {
                erroBuilder.Append($" Propiedad: {item.PropertyName}. Error: {item.ErrorMessage} ");
            }

            return SetResult(context, StatusCodes.Status400BadRequest,
               "Error de los datos de entradas", erroBuilder.ToString());
        }
    }
}
