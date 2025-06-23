using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
            this.ReportLevel = LogType.Info;
        }

        public LogType ReportLevel { get; set; }

        public void AppendLog(string date, string msg, LogType type)
        {
            if (type >= this.ReportLevel)
            {
                Console.Write(this.layout.FormatLog(date, msg, type));
            }
        }
    }
}
