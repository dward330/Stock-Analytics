using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Stock_Analytics.Domain_Models.Logger;

namespace Stock_Analytics.Loggers
{
    public class DLogger
    {
        #region Fields

        private readonly Object _logQueueLock = new Object(); //Will be used for logging queue thread management
        private readonly Object _logDestinationLock = new Object(); //Will be used for log writing thread management
        private List<DLoggerMessage> _logQueue = new List<DLoggerMessage>();
        private String logFileName = "DLogger";
        private String logFileFullPath = null;
        private LogLevel _LogLevel = LogLevel.Info;
        private TextWriter _FileWriter = null;
        private int WaitTime_ForDequeueAllLogMessages = 10;
        private Thread LogMessageDequeueThread = null;
        private Boolean LoggerShuttingDown = false;
        private Boolean LoggerDequeuerOffline = false;

        public enum LogLevel { Error = 0, Warning = 1, Info = 2};

        #endregion

        #region Contructors

        public DLogger()
        {
            this.StartUpLogger();
        }

        public DLogger(String logFileName = "DLogger")
        {
            this.logFileName = logFileName;

            lock (this._logDestinationLock)
            {
                this.StartUpLogger();
            }
        }

        public DLogger(LogLevel logLevel, String logFileName = "DLogger")
        {
            this._LogLevel = logLevel;
            this.logFileName = logFileName;

            lock (this._logDestinationLock)
            {
                this.StartUpLogger();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Completes Start Up Operations for Logger
        /// </summary>
        private void StartUpLogger()
        {
            lock (this._logDestinationLock)
            {
                String timeNow = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                String tempLogFullPath = String.Format("{0}\\{1}_{2}.txt", Directory.GetCurrentDirectory(), this.logFileName, timeNow);
                String tempAlternativeLogFullPath = String.Format("{0}\\{1}_{2}_{3}.txt", Directory.GetCurrentDirectory(), this.logFileName, timeNow, new Guid());

                if (!File.Exists(tempLogFullPath))
                {
                    this._FileWriter = File.CreateText(tempLogFullPath);
                    this.logFileFullPath = tempLogFullPath;
                }
                else
                {
                    this._FileWriter = File.CreateText(tempAlternativeLogFullPath);
                    this.logFileFullPath = tempAlternativeLogFullPath;
                }
            }

            //Log Start up Message
            this.QueueLogMessage("Logger has started and is running...", LogLevel.Info, typeof(DLogger));

            //Start Logging Queued up Messages
            this.LogMessageDequeueThread = new Thread(LogAndDequeueAllLogMessages);
            this.LogMessageDequeueThread.IsBackground = true;
            this.LogMessageDequeueThread.Start();
        }

        /// <summary>
        /// Adds a Message to the Log Queue, to be logged.
        /// </summary>
        /// <param name="logMessage"> String Type: Log message to be added to the queue</param>
        /// <returns>Boolean Type: Confirmation Message was added to the log queue</returns>
        public Boolean QueueLogMessage(String logMessage, LogLevel logLevel = LogLevel.Info, Type classLogging = null)
        {
            Boolean tempMessageQueued = false;

            try
            {
                lock (this._logQueueLock)
                {
                    if (null != this._logQueue)
                    {
                        #region Add the message to the queue to be logged

                        DLoggerMessage tempDLoggerMessage = new DLoggerMessage()
                        {
                            MessageId = new Guid().ToString(),
                            MessageDateTimeStamp = DateTime.Now,
                            Message = logMessage,
                            LogLevel = logLevel,
                            ClassLogging = classLogging
                        };
                        this._logQueue.Add(tempDLoggerMessage);

                        #endregion

                        #region Verify the Message was added to the queue

                        if (
                            this._logQueue.Exists(
                                x => x.Message.Equals(logMessage, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            tempMessageQueued = true;
                        }

                        #endregion
                    }
                }
            }
            catch(Exception e)
            {
               throw new Exception(String.Format("{0} - {1}","Error Adding Message to Log Queue!",e));   
            }

            return tempMessageQueued;
        }

        /// <summary>
        /// Logs and Dequeues all Log Messages
        /// </summary>
        /// <param name="logLevel"></param>
        public void LogAndDequeueAllLogMessages()
        {
            while (true)
            {
                lock (this._logQueueLock)
                {
                    lock (this._logDestinationLock)
                    {
                        if (null != this._logQueue && !this.LoggerDequeuerOffline)
                        {
                            foreach (DLoggerMessage logMessage in this._logQueue)
                            {
                                if (null != this._FileWriter && ((int) logMessage.LogLevel) <= (int) this._LogLevel)
                                {
                                    this._FileWriter.WriteLine(String.Format("{0}-{1} -> {2}: {3}",
                                        logMessage.ClassLogging.Name,
                                        logMessage.MessageDateTimeStamp.ToString("yyyy-MM-dd_HH-mm-ss"), logMessage.LogLevel.ToString(),
                                        logMessage.Message));
                                }
                            }
                        }

                        if (this.LoggerShuttingDown && null != this._FileWriter)
                        {
                            this._FileWriter.Dispose();
                            this.LoggerDequeuerOffline = true;
                        }
                    }
                }

                Thread.Sleep(this.WaitTime_ForDequeueAllLogMessages);
            }
        }

        /// <summary>
        /// Releases all the logger's resources
        /// </summary>
        public void Dispose()
        {
            this.LoggerShuttingDown = true;

            //Wait until we finished dequeuing messages
            while (!this.LoggerDequeuerOffline)
                Thread.Sleep(1000);

            this._logQueue = null;
            this.logFileName = null;
            this.logFileFullPath = null;
            this._FileWriter = null;
    }

        #endregion
    }
}
