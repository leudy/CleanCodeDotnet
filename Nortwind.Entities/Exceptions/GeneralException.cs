using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Entities.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException()
        {

        }
        public string Details { get; set; }
        public GeneralException(string message) : base(message)
        {

        }
        public GeneralException(string message, Exception inner) : base(message, inner)
        {

        }
        public GeneralException(string title, string details) : base(title) => Details = details;

    }
}
