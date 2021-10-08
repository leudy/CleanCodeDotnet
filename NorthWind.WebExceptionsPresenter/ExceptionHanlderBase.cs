using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class ExceptionHanlderBase
    {
        readonly Dictionary<int, string> RFC7231Types =
            new Dictionary<int, string>
            {
                { StatusCodes.Status500InternalServerError,
                "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1" },
                {
                    StatusCodes.Status400BadRequest,
                    "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"
                }


            };
        public Task SetResult(ExceptionContext context,int? status,string title,string details)
        {

            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RFC7231Types.ContainsKey(status.Value) ? RFC7231Types[status.Value] :"",
                Detail = details
            };



            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = status
            };

            return Task.CompletedTask;
        }
    }
}
