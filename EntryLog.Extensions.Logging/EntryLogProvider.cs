using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public class EntryLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            // Create an instance for the EntryLog
            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
