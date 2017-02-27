namespace ToyRobot.Lib
{
    public interface IControllableRobot
    {
        void RotateLeft();
        void RotateRight();
        void Move();
        void Report();
    }

    public interface IRobot : IControllableRobot
    {
        void Initialise(Bounds surface, Point coordinates, string facing);
    }

    public class Robot : IRobot
    {
        public IRobotStateFactory StateFactory { get; private set; }
        public IRobotState State { get; private set; }

        public Robot(IRobotStateFactory stateFactory)
        {
            StateFactory = stateFactory;
            State = StateFactory.UninitialisedState();
        }

        public void Initialise(Bounds surface, Point coordinates, string facing)
        {
            State = StateFactory.InitialisedState(surface, coordinates, facing);
        }

        public void RotateLeft()
        {
            State.RotateLeft();
        }

        public void RotateRight()
        {
            State.RotateRight();
        }

        public void Move()
        {
            State.Move();
        }

        public void Report()
        {
            State.Report();
        }
    }
}
