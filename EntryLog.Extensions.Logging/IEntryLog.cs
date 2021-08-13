using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public interface IEntryLog
    {
        void Log(string folder, Exception exception);
        void Log(string folder, string message);
    }
}
