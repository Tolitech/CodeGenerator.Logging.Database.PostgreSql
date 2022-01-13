using System;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Xunit;

namespace Tolitech.CodeGenerator.Logging.Database.PostgreSql.Tests
{
    public class LoggingDatabasePostgreSqlTest
    {
        private const string CONNECTION_STRING = "Host=localhost;Port=5432;Pooling=true;Database=Logging;User Id=postgres;Password=Password@123;";

        private readonly ILogger<LoggingDatabasePostgreSqlTest> _logger;

        public LoggingDatabasePostgreSqlTest()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var logLevel = (LogLevel)config.GetSection("Logging:Database:LogLevel").GetValue(typeof(LogLevel), "Default");

            var loggerFactory = LoggerFactory.Create(logger =>
            {
                logger
                    .AddConfiguration(config.GetSection("Logging"))
                    .AddPostgreSqlDatabaseLogger(x =>
                    {
                        x.LogLevel = logLevel;
                        x.ConnectionString = CONNECTION_STRING;
                    });
            });

            _logger = loggerFactory.CreateLogger<LoggingDatabasePostgreSqlTest>();
        }

        [Fact(DisplayName = "LoggingDatabasePostgreSql - Log - Valid")]
        public void LoggingDatabasePostgreSql_LogEntry_Valid()
        {
            _logger.LogTrace("Trace");
            _logger.LogDebug("Debug");
            _logger.LogInformation("Information");
            _logger.LogWarning("Warning");
            _logger.LogError("Error");
            _logger.LogCritical("Critical");
            Thread.Sleep(5000);

            string selectCount = "select count(*) from \"Cg\".\"Log\"";
            using var conn = new NpgsqlConnection(CONNECTION_STRING);
            using var command = new NpgsqlCommand(selectCount, conn);
            conn.Open();
            long? count = (long?)command.ExecuteScalar();
            conn.Close();

            Assert.True(count > 0);
        }
    }
}
