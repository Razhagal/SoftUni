using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface ILayout
    {
        string FormatLog(string date, string msg, LogType type);
    }
}
