using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LogFile
    {
        private StringBuilder sbContent;

        public LogFile()
        {
            this.sbContent = new StringBuilder();
        }

        public int Size { get { return this.sbContent.ToString().Where(c => char.IsLetter(c)).Sum(c => c); } }

        public void Write(string log)
        {
            this.sbContent.Append(log);

            using (StreamWriter writer = File.AppendText("../../../output.txt"))
            {
                writer.WriteLine(log);
            }
        }
    }
}
