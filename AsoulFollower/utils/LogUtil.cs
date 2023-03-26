using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoulFollower.utils
{
    public class LogUtil
    {
        private MainWindow window;
        public LogUtil(MainWindow window)
        {
            this.window = window;
        }

        public async Task Logger(LoggerType type, String content)
        {
            var time = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local);
            LogObject log = new LogObject();
            switch (type)
            {
                case LoggerType.Info:
                    log = new LogObject { Content = content, Type = "INFO", Time = String.Format("{0,2:00}:{1,2:00}:{2,2:00}", time.Hour, time.Minute, time.Second) };
                    break;
                case LoggerType.Error:
                    log = new LogObject { Content = content, Type = "ERROR", Time = String.Format("{0,2:00}:{1,2:00}:{2,2:00}", time.Hour, time.Minute, time.Second) };
                    break;
                case LoggerType.Warning:
                    log = new LogObject { Content = content, Type = "WARNING", Time = String.Format("{0,2:00}:{1,2:00}:{2,2:00}", time.Hour, time.Minute, time.Second) };
                    break;
            }
            window.ListView_Log.Items.Add(log);
        }
        public class LogObject
        {
            public String Type { get; set; }
            public String Time { get; set; }
            public String Content { get; set; }
        }
    }

    /// <summary>
    /// Info:0
    /// Error:1
    /// WARNING:2
    /// </summary>
    public enum LoggerType
    {
        Info, Error, Warning
    }
}
