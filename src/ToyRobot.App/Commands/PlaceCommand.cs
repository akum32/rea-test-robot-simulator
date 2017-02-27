using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly ISimulator _simulator;

        public PlaceCommand(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute(string args)
        {
            var parsedArgs = new PlaceArgsParser(args).Parse();
            _simulator.PlaceRobot(parsedArgs.Coordinates, parsedArgs.Facing);
        }
    }
}
