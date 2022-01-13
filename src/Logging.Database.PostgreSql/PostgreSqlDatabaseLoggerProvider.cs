using System;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Tolitech.CodeGenerator.Logging.Database.PostgreSql
{
    [ProviderAlias("Database")]
    public class PostgreSqlDatabaseLoggerProvider : DatabaseLoggerProvider
    {
        public PostgreSqlDatabaseLoggerProvider(IOptionsMonitor<DatabaseLoggerOptions> settings) : base(settings.CurrentValue)
        {

        }

        public PostgreSqlDatabaseLoggerProvider(DatabaseLoggerOptions settings) : base(settings)
        {

        }

        protected override DbConnection GetNewConnection
        {
            get
            {
                return new NpgsqlConnection(Settings.ConnectionString);
            }
        }

        protected override string Sql
        {
            get
            {
                return @"insert into ""Cg"".""Log"" 
                    (""LogId"", ""Time"", ""UserName"", ""HostName"", ""Category"", ""Level"", ""Text"", ""Exception"", ""EventId"", ""ActivityId"", ""UserId"", ""LoginName"", ""ActionId"", ""ActionName"", ""RequestId"", ""RequestPath"", ""FilePath"", ""Sql"", ""Parameters"", ""StateText"", ""StateProperties"", ""ScopeText"", ""ScopeProperties"") 
                    values 
                    (@logId, @time, @userName, @hostName, @category, @level, @text, @exception, @eventId, @activityId, @userId, @loginName, @actionId, @actionName, @requestId, @requestPath, @filePath, @sql, @parameters, @stateText, @stateProperties, @scopeText, @scopeProperties)";
            }
        }
    }
}
