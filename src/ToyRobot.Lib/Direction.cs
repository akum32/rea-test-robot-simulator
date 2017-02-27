namespace ToyRobot.Lib
{
    public interface IDirection
    {
        string Name { get; }
        Point Offset { get; }
    }

    public class Direction : IDirection
    {
        public string Name { get; private set; }
        public Point Offset { get; private set; }

        public Direction(string name, Point offset)
        {
            Name = name;
            Offset = offset;
        }
    }
}
