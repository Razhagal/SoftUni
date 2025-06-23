using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        private LogFile file;

        public FileAppender(ILayout layout, LogFile file)
        {
            this.layout = layout;
            this.file = file;
            this.ReportLevel = LogType.Info;
        }

        public LogType ReportLevel { get; set; }

        public void AppendLog(string date, string msg, LogType type)
        {
            if (type >= this.ReportLevel)
            {
                this.file.Write(this.layout.FormatLog(date, msg, type));
            }
        }
    }
}
