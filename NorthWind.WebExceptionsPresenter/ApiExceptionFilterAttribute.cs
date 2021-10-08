﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> ExceptionHandlers;
        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
            => ExceptionHandlers = exceptionHandlers;

        public override void OnException(ExceptionContext context)
        {
            Type ExceptionType = context.Exception.GetType();
            if (ExceptionHandlers.ContainsKey(ExceptionType))
            {
                ExceptionHandlers[ExceptionType].handler(context);
            }
            else
            {
                new ExceptionHanlderBase()
                    .SetResult(context,
                    StatusCodes.Status500InternalServerError,
                    "Ha Ocurrido un error al procesar la repuesta",
                    "");
            }


            base.OnException(context);
        }
    }
}
