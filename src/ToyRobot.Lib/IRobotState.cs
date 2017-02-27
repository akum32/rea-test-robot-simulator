namespace ToyRobot.Lib
{
    public interface IRobotState
    {
        void RotateLeft();
        void RotateRight();
        void Move();
        void Report();
    }
}
