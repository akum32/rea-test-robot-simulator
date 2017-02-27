using System;

namespace ToyRobot.App
{
    public interface ICommandReader
    {
        string NextCommand();
    }

    public class ConsoleCommandReader : ICommandReader
    {
        public string NextCommand()
        {
            var command = Console.ReadLine();
            return IsExitCommand(command) ? null : command;
        }

        private static bool IsExitCommand(string command)
        {
            return command.Trim().ToUpper().Equals("EXIT");
        }
    }
}
