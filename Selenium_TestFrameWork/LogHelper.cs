using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.IO;

namespace Selenium_TestFrameWork
{
    public static class LogHelper
    {
        private static readonly RollingFileAppender _rollingFileAppender;
        private static readonly Hierarchy _hierarchy;

        public static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        // Constructor requires the file log4net.config be in the bin debug folder        
        static LogHelper()
        {
            var log4NetConfig = new FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(log4NetConfig);
            _hierarchy = (Hierarchy)LogManager.GetRepository();
            _rollingFileAppender = (RollingFileAppender)_hierarchy.Root.GetAppender("RollingAppender");
        }

        public static void Debug(object message)
        {
            log.Debug(message);
        }
        public static void Info(object message)
        {
            log.Info(message);
        }

        public static void Info(object message, Exception exception)
        {
            log.Info(message, exception);
        }
        public static void Error(object message)
        {
            log.Error(message);
        }
        public static void Fatal(object message)
        {
            log.Fatal(message);
        }
        public static void Warn(object message)
        {
            log.Warn(message);
        }
    }
}
