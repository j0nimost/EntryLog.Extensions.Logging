using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public class EntryLogger : ILogger
    {
        private readonly string _name;
        private readonly Func<EntryLogConfiguration> _getconfig;
        private readonly IEntryLog _entry;

        public EntryLogger(string name, Func<EntryLogConfiguration> getConfig, IEntryLog entryLog)
        {
            this._name = name;
            this._getconfig = getConfig;
            this._entry = entryLog;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _getconfig().LogTypes.ContainsKey(logLevel); // if loglevel is supported
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                // Don't Log anything if not existing
                return;
            }
            EntryLogConfiguration config = _getconfig(); // configs
            // Switch Through
            switch(config.LogTypes[logLevel])
            {
                case LogType.Audit:
                    // write to Audit Folder
                    break;
                case LogType.Error:
                    // write to Audit Folder
                    break;
                case LogType.Warning:
                    // write to Audit Folder
                    break;
            }
        }
    }
}
