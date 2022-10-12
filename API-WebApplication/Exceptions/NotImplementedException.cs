using System;

namespace API_WebApplication.Exceptions
{
    /// <summary>
    /// This class handles NotImplemented exception
    /// </summary>
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message) { }
    }
}
