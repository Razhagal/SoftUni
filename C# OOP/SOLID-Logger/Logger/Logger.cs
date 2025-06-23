using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        public Logger(params IAppender[] appender)
        {
            this.appenders = new List<IAppender>(appender);
        }

        public void Info(string date, string msg)
        {
            NotifyAppenders(date, msg, LogType.Info);
        }

        public void Warning(string date, string msg)
        {
            NotifyAppenders(date, msg, LogType.Warning);
        }

        public void Error(string date, string msg)
        {
            NotifyAppenders(date, msg, LogType.Error);
        }

        public void Critical(string date, string msg)
        {
            NotifyAppenders(date, msg, LogType.Critical);
        }

        public void Fatal(string date, string msg)
        {
            NotifyAppenders(date, msg, LogType.Fatal);
        }

        private void NotifyAppenders(string dateTime, string msg, LogType type)
        {
            for (int i = 0; i < this.appenders.Count; i++)
            {
                this.appenders[i].AppendLog(dateTime, msg, type);
            }
        }
    }
}
