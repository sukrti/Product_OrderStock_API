using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebApplication.Exceptions
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message) { }
    }
}
