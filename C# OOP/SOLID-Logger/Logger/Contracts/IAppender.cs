using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppender
    {
        void AppendLog(string date, string msg, LogType type);

        LogType ReportLevel { get; }
    }
}
