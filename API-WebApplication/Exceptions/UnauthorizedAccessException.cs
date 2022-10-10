using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebApplication.Exceptions
{
    public class UnauthorizedAccessException:Exception
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }
}
