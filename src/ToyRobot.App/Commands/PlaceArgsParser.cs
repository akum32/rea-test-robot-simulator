using System;
using System.Collections.Generic;
using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public class PlaceArgsParser
    {
        private readonly string _textArgs;

        public PlaceArgsParser(string textArgs)
        {
            _textArgs = textArgs.Trim();
        }

        public PlaceArgs Parse()
        {
            var items = _textArgs.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            return new PlaceArgs(ParseCoordinate(items),
                                 ParseFacing(items));
        }

        private static Point ParseCoordinate(IList<string> items)
        {
            try
            {
                var x = int.Parse(items[0]);
                var y = int.Parse(items[1]);
                return new Point(x, y);
            }
            catch (Exception e)
            {
                throw new Exception("Can't determine coordinates!", e);
            }
        }

        private static string ParseFacing(IList<string> items)
        {
            try
            {
                return items[2];
            }
            catch (Exception e)
            {
                throw new Exception("Can't determine direction!", e);
            }
        }
    }
}
