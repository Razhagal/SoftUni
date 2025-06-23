using Logger.Contracts;
using System;
using System.Linq;

namespace Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //ILayout layout = new SimpleLayout();

            //LogFile file = new LogFile();
            //IAppender fileAppender = new FileAppender(layout, file);

            //ILogger logger = new Logger(fileAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //Console.WriteLine(("3/31/2015 5:33:07 PM - ERROR - Error parsing request").ToString().Where(c => char.IsLetter(c)).Sum(c => c));

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = LogType.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


        }
    }
}
