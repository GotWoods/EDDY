using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace EdiParser
{
    public static class Logging
    {
        //public static ILogger logger;

        public static ILoggerFactory LoggerFactory { get; set; }
        //public static ILoggerProvider Provider { get; set; }

        static Logging()
        {
            LoggerFactory = new NullLoggerFactory(); //default to null logger
            //  Provider = NullLoggerProvider.Instance;
        }

        public static ILogger<T> Logger<T>()
        {
            return LoggerFactory.CreateLogger<T>();
        }
    }
}
