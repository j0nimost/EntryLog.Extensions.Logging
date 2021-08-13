using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public class EntryLog : IEntryLog
    {
        public EntryLog()
        {

        }
        public void Log(string folder, Exception exception)
        {
            // Iterate through the exception body
            // Format to the needed style
        }

        public void Log(string folder, string message)
        {
            // Old school write directly to the file
        }
    }
}
