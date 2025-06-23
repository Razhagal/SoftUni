using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        { }

        public string FormatLog(string dateTime, string msg, LogType type)
        {
            return $"{dateTime} - {type} - {msg}{Environment.NewLine}";
        }
    }
}
