using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Constants;

    public class EnvironmentConstants
    {
        public static string TOKEN_KEY = Environment.GetEnvironmentVariable("TOKEN_KEY");
        public static bool DEBUG = Convert.ToBoolean(Environment.GetEnvironmentVariable("DEBUG"));
        public static string CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    }

