namespace ToyRobot.Lib
{
    public interface IRobotStateFactory
    {
        IRobotState UninitialisedState();
        IRobotState InitialisedState(Bounds surface, Point coordinates, string facing);
    }

    public class RobotStateFactory : IRobotStateFactory
    {
        public IRobotReporter Reporter { get; private set; }

        public RobotStateFactory(IRobotReporter reporter)
        {
            Reporter = reporter;
        }

        public IRobotState UninitialisedState()
        {
            return new UnInitialisedState();
        }

        public IRobotState InitialisedState(Bounds surface, Point coordinates, string facing)
        {
            return new InitialisedState(surface, coordinates, new Compass(facing), Reporter);
        }
    }
}
