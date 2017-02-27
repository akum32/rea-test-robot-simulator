namespace ToyRobot.Lib
{
    public interface IRobotReporter
    {
        void Report(Point coordinates, IDirection direction);
    }
}
