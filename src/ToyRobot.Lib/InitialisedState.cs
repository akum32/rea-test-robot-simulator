namespace ToyRobot.Lib
{
    public class InitialisedState : IRobotState
    {
        public Bounds Surface { get; private set; }
        public Point Coordinates { get; private set; }
        public ICompass Compass { get; private set; }
        public IRobotReporter Reporter { get; private set; }

        public InitialisedState(
            Bounds surface, Point coordinates, ICompass compass, IRobotReporter reporter)
        {
            Surface = surface;
            Coordinates = coordinates;
            Compass = compass;
            Reporter = reporter;
        }
        
        public void RotateLeft()
        {
            Compass.Left();
        }

        public void RotateRight()
        {
            Compass.Right();
        }

        public void Move()
        {
            var offset = Compass.Facing.Offset;
            var nextPoint = Coordinates + offset;
            if (Surface.Contains(nextPoint))
                Coordinates = nextPoint;
        }

        public void Report()
        {
            Reporter.Report(Coordinates, Compass.Facing);
        }

    }
}
