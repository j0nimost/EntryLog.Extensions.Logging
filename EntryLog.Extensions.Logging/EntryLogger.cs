using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public class EntryLogger : IEntryLog
    {
        private readonly string _name;
        private readonly Func<EntryLogConfiguration> _getconfig;

        public EntryLogger(string name, Func<EntryLogConfiguration> getConfig)
        {
            this._name = name;
            this._getconfig = getConfig;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return default;
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
                    LogType.Audit.StreamWritter($"{_name} -  {formatter(state, exception)}");
                    break;
                case LogType.Error:
                    // write to Audit Folder
                    LogType.Error.StreamWritter($"{_name} -  {formatter(state, exception)}");
                    break;
                case LogType.Warning:
                    // write to Audit Folder
                    LogType.Warning.StreamWritter($"{_name} -  {formatter(state, exception)}");
                    break;
            }
        }
    }
}
