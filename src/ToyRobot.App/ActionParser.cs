using System;
using System.Linq;

namespace ToyRobot.App
{
    public interface IActionParser
    {
        Action Parse(string text);
    }

    public class ActionParser : IActionParser
    {
        public Action Parse(string text)
        {
            text = text ?? string.Empty;
            var parts = text.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            var type = parts.ElementAtOrDefault(0) ?? string.Empty;
            var args = parts.ElementAtOrDefault(1) ?? string.Empty;
            return new Action(type, args);
        }
    }
}
