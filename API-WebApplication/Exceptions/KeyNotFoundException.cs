using System;

namespace API_WebApplication.Exceptions
{
    /// <summary>
    /// This class handles KeyNotFound exception
    /// </summary>
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message) : base(message) { }
    }
}
