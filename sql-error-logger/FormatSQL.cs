namespace Drivr.NHibernate.SqlErrorLogger
{
    using System.Text;

    using global::NHibernate.AdoNet.Util;

    public class FormatSql
    {
        public static string ApplyFormat(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                return string.Empty;
            }

            sql = sql.Trim();

            if (sql.ToLowerInvariant().StartsWith("create table"))
            {
                return sql;
            }

            if (sql.ToLowerInvariant().StartsWith("alter table") || sql.ToLowerInvariant().StartsWith("comment on"))
            {
                sql = new DdlFormatter().Format(sql);
            }
            else
            {
                sql = new BasicFormatter().Format(sql).Trim();
            }

            return FormatParams(sql);
        }

        private static string FormatParams(string sql)
        {
            if (!sql.Contains(";"))
            {
                return sql;
            }

            var sqlLines = sql.Split(';');

            var sb = new StringBuilder();
            foreach (var line in sqlLines)
            {
                if (line.Trim().StartsWith("@p"))
                {
                    var paramsLines = line.Split(',');

                    foreach (var paramLine in paramsLines)
                    {
                        sb.AppendLine(paramLine.Trim());
                    }
                }
                else
                {
                    sb.AppendLine(line.Trim() + ";\n");
                }
            }

            return sb.ToString();
        }
    }
}
