namespace Drivr.NHibernate.SqlErrorLogger
{
    using System;

    using global::NHibernate;

    using log4net;

    public class GeneralLogger : IInternalLogger
    {
        public static readonly ILog Log = LogManager.GetLogger("Drivr.NHibernate.Logging.EventsLogger");

        public bool IsErrorEnabled
        {
            get { return true; }
        }

        public bool IsFatalEnabled
        {
            get { return true; }
        }

        public bool IsDebugEnabled
        {
            get { return true; }
        }

        public bool IsInfoEnabled
        {
            get { return true; }
        }

        public bool IsWarnEnabled
        {
            get { return true; }
        }

        public static void FlushMessages()
        {
            try
            {
                foreach (var message in SessionStartLogger.Messages)
                {
                    Log.Logger.Log(message);
                }

                SessionStartLogger.Messages.Clear();
            }
            catch
            {
            }
        }

        public static void CacheMessage(string message)
        {
            var logEvent = new log4net.Core.LoggingEvent(
                typeof(GeneralLogger),
                Log.Logger.Repository,
                Log.Logger.Name,
                log4net.Core.Level.Debug,
                message,
                null);

            SessionStartLogger.Messages.Add(logEvent);
        }

        public void Error(object message)
        {
            Log.Error(message);
            FlushMessages();
        }

        public void Error(object message, Exception exception)
        {
            Log.Error(message, exception);
            FlushMessages();
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Log.Error(string.Format(format, args));
            FlushMessages();
        }

        public void Fatal(object message)
        {
            Log.Fatal(message);
            FlushMessages();
        }

        public void Fatal(object message, Exception exception)
        {
            Log.Fatal(message, exception);
            FlushMessages();
        }

        public void Debug(object message)
        {
        }

        public void Debug(object message, Exception exception)
        {
        }

        public void DebugFormat(string format, params object[] args)
        {
        }

        public void Info(object message)
        {
        }

        public void Info(object message, Exception exception)
        {
        }

        public void InfoFormat(string format, params object[] args)
        {
        }

        public void Warn(object message)
        {
        }

        public void Warn(object message, Exception exception)
        {
        }

        public void WarnFormat(string format, params object[] args)
        {
        }
    }
}
