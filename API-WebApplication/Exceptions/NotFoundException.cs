using System;

namespace API_WebApplication.Exceptions
{
    /// <summary>
    /// This class handles NotFound exception
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
