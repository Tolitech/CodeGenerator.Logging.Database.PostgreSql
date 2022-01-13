using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Tolitech.CodeGenerator.Logging.Database.PostgreSql
{
    public static class PostgreSqlDatabaseLoggerExtensions
    {
        static public ILoggingBuilder AddPostgreSqlDatabaseLogger(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, PostgreSqlDatabaseLoggerProvider>());
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IOptionsChangeTokenSource<DatabaseLoggerOptions>, LoggerProviderOptionsChangeTokenSource<DatabaseLoggerOptions, PostgreSqlDatabaseLoggerProvider>>());
            return DatabaseLoggerExtensions.AddDatabaseLogger(builder);
        }

        static public ILoggingBuilder AddPostgreSqlDatabaseLogger(this ILoggingBuilder builder, Action<DatabaseLoggerOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddPostgreSqlDatabaseLogger();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
