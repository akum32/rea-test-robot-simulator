using ToyRobot.Lib;

namespace ToyRobot.App.Tests
{
    public class TestWriter : ITextWriter
    {
        public string Text { get; private set; }

        public void Write(string text)
        {
            Text = text;
        }
    }
}
