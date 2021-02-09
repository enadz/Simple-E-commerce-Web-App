using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.ExceptionHandler
{
    public class UserExceptionHandler:Exception
    {
        public UserExceptionHandler()
        { }

        public UserExceptionHandler(string message)
            : base(message)
        { }

        public UserExceptionHandler(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
