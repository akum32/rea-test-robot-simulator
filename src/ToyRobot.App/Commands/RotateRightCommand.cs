using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public class RotateRightCommand : ICommand
    {
        private readonly ISimulator _simulator;

        public RotateRightCommand(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute(string args)
        {
            _simulator.Robot.RotateRight();
        }
    }
}
