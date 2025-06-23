using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        { }

        public string FormatLog(string date, string msg, LogType type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"   <date>{date}</date>");
            sb.AppendLine($"   <level>{type}</level>");
            sb.AppendLine($"   <message>{msg}</message>");
            sb.AppendLine("</log>");

            return sb.ToString();
        }
    }
}
