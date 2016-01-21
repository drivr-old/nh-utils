namespace Drivr.NHibernate.SqlErrorLogger
{
    using System;
    using System.Collections.Generic;

    public class SessionStartLogger : SqlLogger
    {
        [ThreadStatic]
        private static List<log4net.Core.LoggingEvent> messages;

        public static List<log4net.Core.LoggingEvent> Messages
        {
            get
            {
                return messages ?? (messages = new List<log4net.Core.LoggingEvent>());
            }
        }

        public override void DebugFormat(string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format) && format.StartsWith("[session-id="))
            {
                Messages.Clear();
            }

            base.DebugFormat(format, args);
        }
    }
}
