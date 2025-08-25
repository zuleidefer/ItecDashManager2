using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Exceptions;

    public class GlobalMessageExceptions : Exception
    {
        public GlobalMessageExceptions(string message) 
        {
        }

        public GlobalMessageExceptions(string message, Exception innerException) 
        {
        }

    }

