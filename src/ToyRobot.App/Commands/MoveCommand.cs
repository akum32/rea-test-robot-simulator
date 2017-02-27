using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly ISimulator _simulator;

        public MoveCommand(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute(string args)
        {
            _simulator.Robot.Move();
        }
    }
}
