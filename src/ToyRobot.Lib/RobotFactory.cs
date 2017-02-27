namespace ToyRobot.Lib
{
    public interface IRobotFactory
    {
        IRobot Create();
    }

    public class RobotFactory : IRobotFactory
    {
        private readonly IRobotReporter _reporter;

        public RobotFactory(IRobotReporter reporter)
        {
            _reporter = reporter;
        }

        public IRobot Create()
        {
            return new Robot(new RobotStateFactory(_reporter));
        }
    }
}
