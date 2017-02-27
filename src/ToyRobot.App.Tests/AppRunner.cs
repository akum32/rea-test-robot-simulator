using ToyRobot.Lib;

namespace ToyRobot.App.Tests
{
    public static class AppRunner
    {
        public static string Execute(params string[] commands)
        {
            return Execute(new Bounds(new Point(0, 0), 5), commands);
        }

        public static string Execute(Bounds surface, params string[] commands)
        {
            var reader = new TestCommandReader(commands);
            var outputter = new TestWriter();
            new App(surface, reader, outputter).Run();
            return outputter.Text;
        }
    }
}
