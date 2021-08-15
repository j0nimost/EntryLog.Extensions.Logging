using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntryLog.Extensions.Logging
{
    public static class EntryLogHandler
    {
        private static string FileNameTimeStamp(LogInterval interval)
        {
            switch (interval)
            {
                case LogInterval.EveryDay:
                    return DateTime.Now.ToString("yyyy-MM-dd");
                case LogInterval.EveryHour:
                    return DateTime.Now.ToString("yyyy-MM-dd HH");
                case LogInterval.EveryMinute:
                    return DateTime.Now.ToString("yyyy-MM-dd HH_mm");
                case LogInterval.EverySecond:
                    return DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss");
            }
            return "";
        }

        private static string FolderCheckerorCreater(this Uri path, LogType logType)
        {
            string foldername = "";

            switch(logType)
            {
                case LogType.Audit:
                    foldername += "Audit";
                    break;
                case LogType.Warning:
                    foldername += "Warning";
                    break;
                case LogType.Error:
                    foldername += "Error";
                    break;
                default:
                    foldername += "Audit";
                    break;
            }


            string FolderPath = path.LocalPath.ToString() + @"\" + foldername;

            // Check LocalPath
            if (!Directory.Exists(path.LocalPath.ToString()))
            {
                Directory.CreateDirectory(path.LocalPath.ToString());
            }

            // Check Folder Path
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            return foldername;
        }

        public static void StreamWritter(this EntryLogConfiguration config, LogType logType, string log)
        {
            string foldername = config.FolderPath.FolderCheckerorCreater(logType);

            string currentTimeFilename = FileNameTimeStamp(config.LogInterval);

            if (!String.IsNullOrEmpty(currentTimeFilename) && !String.IsNullOrEmpty(foldername))
            {
                string path = config.FolderPath.LocalPath.ToString() + "\\" + foldername + "\\" + currentTimeFilename + " - " + $"{foldername}.log";

                var fileStreamer = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                var streamWriter = new StreamWriter(fileStreamer);

                try
                {
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    streamWriter.WriteLine(" " + currentTime);
                    streamWriter.WriteLine("***************************************************");
                    streamWriter.WriteLine(log);
                    streamWriter.WriteLine("---------------------------------------------------------------------------------------------------");

                }
                finally
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
        }
    }
}
