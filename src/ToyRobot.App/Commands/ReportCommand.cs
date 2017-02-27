using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public class ReportCommand : ICommand
    {
        private readonly ISimulator _simulator;

        public ReportCommand(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute(string args)
        {
            _simulator.Robot.Report();
        }
    }
}
