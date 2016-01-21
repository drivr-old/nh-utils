namespace Drivr.NHibernate.SqlErrorLogger
{
    using global::NHibernate;

    public class LoggerFactory : ILoggerFactory
    {
        public IInternalLogger LoggerFor(System.Type type)
        {
            if (type == null)
            {
                return new NoLoggingInternalLogger();
            }

            return this.LoggerFor(type.ToString());
        }

        public IInternalLogger LoggerFor(string keyName)
        {
            if (string.IsNullOrWhiteSpace(keyName))
            {
                return new NoLoggingInternalLogger();
            }

            if (keyName != "NHibernate.SQL" && keyName != "NHibernate.Impl.SessionImpl")
            {
                return new GeneralLogger();
            }

            if (keyName == "NHibernate.Impl.SessionImpl")
            {
                return new SessionStartLogger();
            }

            return new SqlLogger();
        }
    }
}
