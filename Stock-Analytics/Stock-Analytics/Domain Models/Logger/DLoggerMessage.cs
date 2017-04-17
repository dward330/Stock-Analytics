using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Analytics.Loggers;

namespace Stock_Analytics.Domain_Models.Logger
{
    public class DLoggerMessage
    {
        public String MessageId { get; set;}
        public DateTime MessageDateTimeStamp { get; set; }
        public String Message { get; set; }
        public DLogger.LogLevel LogLevel { get; set; }
        public Type ClassLogging { get; set; }
    }
}
