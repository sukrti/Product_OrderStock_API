using System;

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
