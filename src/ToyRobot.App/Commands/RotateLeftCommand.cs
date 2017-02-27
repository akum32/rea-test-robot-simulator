using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public class RotateLeftCommand : ICommand
    {
        private readonly ISimulator _simulator;

        public RotateLeftCommand(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute(string args)
        {
            _simulator.Robot.RotateLeft();
        }
    }
}
