using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Stock_Analytics.Loggers;

namespace Stock_Analytics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start Logger
            DLogger mainProgramLogger = new DLogger(DLogger.LogLevel.Info,"Stock_Analytics");

            //Start Up Message
            String startMessage = String.Format("{0}{1}", "Welcom to Stock Analytics - Ver.", Assembly.GetExecutingAssembly().GetName().Version);
            Console.WriteLine(startMessage);
            mainProgramLogger.QueueLogMessage(startMessage, DLogger.LogLevel.Info, typeof(Program));

            mainProgramLogger.Dispose();
        }
    }
}
