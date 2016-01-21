# nh-utils
Utilities for NHibernate

## sql-error-logger
This library is dedicated to deal with deadlocks. It logs in memory all SQL queries executed during the session and if SQL error happens, it pushes log to log4net. In that way together with exception we have all SQL queries which was executed by NHibernate in current session.

### Configuration
To enable sql-error-logger, you must add it to your project (or your projects bin folder) and add setting in your configuration file (app.config or web.config) appSettings section:
```
<add key="nhibernate-logger" value="Drivr.NHibernate.SqlErrorLogger.LoggerFactory, Drivr.NHibernate.SqlErrorLogger" />
```
Also you need to add following lines to your log4net configuration, because logger logs SQL queries in DEBUG level:
```
    <logger name="Drivr.NHibernate.Logging.EventsLogger">
      <level value="DEBUG" />
    </logger>
```
You should be aware that log event timestamp matches the time when query was executed.