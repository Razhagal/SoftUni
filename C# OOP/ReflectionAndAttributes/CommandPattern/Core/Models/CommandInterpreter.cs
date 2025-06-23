using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = splitArgs[0];

            Type[] assemblyTypes = Assembly.GetCallingAssembly().GetTypes();
            ICommand command = null;
            foreach (Type type in assemblyTypes)
            {
                if (type.Name.Equals($"{commandName}Command"))
                {
                    command = Activator.CreateInstance(type) as ICommand;
                    break;
                }
            }

            if (command == null)
            {
                return null;
            }

            string[] commandArgs = splitArgs.Skip(1).ToArray();
            //Array.Copy(splitArgs, 1, commandArgs, 0, splitArgs.Length - 1);

            return command.Execute(commandArgs);
        }
    }
}
