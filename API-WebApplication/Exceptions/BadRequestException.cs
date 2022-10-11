using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebApplication.Exceptions
{
    /// <summary>
    /// This class handles BadRequest exception
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
