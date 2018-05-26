using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message = null) : base(message)
        {
        }
    }
}
