namespace Drivr.NHibernate.SqlErrorLogger
{
    using System;

    using global::NHibernate;

    public class SqlLogger : IInternalLogger
    {
        public bool IsDebugEnabled
        {
            get { return true; }
        }

        public bool IsErrorEnabled
        {
            get { return true; }
        }

        public bool IsFatalEnabled
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

        public void Debug(object message)
        {
            if (message == null)
            {
                return;
            }

            GeneralLogger.CacheMessage(FormatSql.ApplyFormat(message.ToString().Trim()));
        }

        public void Debug(object message, Exception exception)
        {
            if (message == null || exception == null)
            {
                return;
            }

            GeneralLogger.CacheMessage(message + "\r\nERROR: " + exception);
        }

        public virtual void DebugFormat(string format, params object[] args)
        {
            GeneralLogger.CacheMessage(FormatSql.ApplyFormat(string.Format(format, args)));
        }

        public void Error(object message)
        {
            GeneralLogger.FlushMessages();
            GeneralLogger.Log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            GeneralLogger.FlushMessages();
            GeneralLogger.Log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            GeneralLogger.FlushMessages();
            GeneralLogger.Log.Error(string.Format(format, args));
        }

        public void Fatal(object message)
        {
            GeneralLogger.FlushMessages();
            GeneralLogger.Log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            GeneralLogger.FlushMessages();
            GeneralLogger.Log.Fatal(message, exception);
        }

        public void Info(object message)
        {
            GeneralLogger.CacheMessage("INFO: " + message);
        }

        public void Info(object message, Exception exception)
        {
            GeneralLogger.CacheMessage("INFO: " + message + "\r\nException: " + exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            GeneralLogger.CacheMessage("INFO: " + string.Format(format, args));
        }

        public void Warn(object message)
        {
            GeneralLogger.CacheMessage("WARN: " + message);
        }

        public void Warn(object message, Exception exception)
        {
            GeneralLogger.CacheMessage("WARN: " + message + "\r\nException: " + exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            GeneralLogger.CacheMessage("WARN: " + string.Format(format, args));
        }
    }
}