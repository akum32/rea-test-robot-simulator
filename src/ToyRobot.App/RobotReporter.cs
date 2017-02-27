using ToyRobot.Lib;

namespace ToyRobot.App
{
    public class RobotReporter : IRobotReporter
    {
        private readonly ITextWriter _writer;

        public RobotReporter(ITextWriter writer)
        {
            _writer = writer;
        }

        public void Report(Point coordinates, IDirection direction)
        {
            var text = string.Format("Status: {0},{1},{2}", coordinates.X, coordinates.Y, direction.Name);
            _writer.Write(text);
        }
    }
}
