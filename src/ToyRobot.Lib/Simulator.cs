namespace ToyRobot.Lib
{
    public interface ISimulator
    {
        IControllableRobot Robot { get; }
        void PlaceRobot(Point coordinates, string direction);
    }

    public class Simulator : ISimulator
    {
        private readonly IRobot _robot;

        public Bounds Surface { get; private set; }
        public IControllableRobot Robot { get { return _robot; }}

        public Simulator(Bounds surface, IRobotFactory robotFactory)
        {
            Surface = surface;
            _robot = robotFactory.Create();
        }

        public void PlaceRobot(Point coordinates, string facing)
        {
            if (Surface.Contains(coordinates))
                _robot.Initialise(Surface, coordinates, facing);
        }
    }
}
