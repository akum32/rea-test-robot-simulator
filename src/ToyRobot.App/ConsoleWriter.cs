using System;
using ToyRobot.Lib;

namespace ToyRobot.App
{
    public class ConsoleWriter : ITextWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
