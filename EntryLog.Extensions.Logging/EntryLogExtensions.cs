using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public static class EntryLogExtensions
    {
        public static ILoggingBuilder AddEntryLog(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();
            builder.Services.Add(ServiceDescriptor.Singleton<ILoggerProvider, EntryLogProvider>());
            return builder;
        }

        public static ILoggingBuilder AddEntryLog(this ILoggingBuilder builder,
                                Action<EntryLogConfiguration> config)
        {
            builder.AddEntryLog();
            builder.Services.Configure(config);

            return builder;
        }
    }
}
