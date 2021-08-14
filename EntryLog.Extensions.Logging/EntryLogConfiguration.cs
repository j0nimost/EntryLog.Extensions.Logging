using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace EntryLog.Extensions.Logging
{
    public enum LogInterval
    {
        EveryDay = 0,
        EveryHour = 1,
        EveryMinute = 2,
        EverySecond = 3
    }
    public enum LogType
    {
        Audit,
        Warning,
        Error
    }
    public class EntryLogConfiguration
    {
        public int EventId { get; set; }
        public static LogInterval LogInterval { get; set; } = LogInterval.EveryHour; // Default
        public static Uri FolderPath { get; set; } = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)); // Default Value

        public Dictionary<LogLevel, LogType> LogTypes = new Dictionary<LogLevel, LogType>()
        {
            {LogLevel.Information, LogType.Audit },
            {LogLevel.Warning, LogType.Warning },
            {LogLevel.Error, LogType.Error }
        };

        // TODO: Provide a means to create custom folder names and write to them
    }
}
