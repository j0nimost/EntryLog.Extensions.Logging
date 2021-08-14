using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public class EntryLogProvider : ILoggerProvider
    {
        private readonly IDisposable _onChangeToken;
        private EntryLogConfiguration _config;
        private readonly ConcurrentDictionary<string, EntryLogger> _logger = new ConcurrentDictionary<string, EntryLogger>();
        public EntryLogProvider(IOptionsMonitor<EntryLogConfiguration> config)
        {
            _config = config.CurrentValue;
            _onChangeToken = config.OnChange(updateConfig => _config = updateConfig);
        }

        private EntryLogConfiguration GetEntryLogConfig() => _config;
        public ILogger CreateLogger(string categoryName)
        {
            // Create an instance for the EntryLog
            return _logger.GetOrAdd(categoryName, name => new EntryLogger(name, GetEntryLogConfig));
        }

        public void Dispose()
        {
            _logger.Clear();
            _onChangeToken.Dispose();
        }
    }
}
