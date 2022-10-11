using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebApplication.Exceptions
{
    /// <summary>
    /// This class handles UnauthorizedAccess exception
    /// </summary>
    public class UnauthorizedAccessException:Exception
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }
}
