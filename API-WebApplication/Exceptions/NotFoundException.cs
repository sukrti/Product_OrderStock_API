using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebApplication.Exceptions
{
    /// <summary>
    /// This class handles NotFound exception
    /// </summary>
    public class NotFoundException:Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
