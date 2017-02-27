using System;
using ToyRobot.Lib;

namespace ToyRobot.App
{
    public class App
    {
        private readonly ICommandReader _commandReader;
        private readonly IActionParser _actionParser;
        private readonly ICommandFactory _commandFactory;
        private readonly ITextWriter _outputter;

        public App(
            Bounds surface,
            ICommandReader commandReader,
            ITextWriter outputter)
        {
            var robotFactory = new RobotFactory(new RobotReporter(outputter));
            var simulator = new Simulator(surface, robotFactory);

            _commandReader = commandReader;
            _outputter = outputter;
            _actionParser = new ActionParser();
            _commandFactory = new CommandFactory(simulator);
        }

        public void Run()
        {
            while(true)
            {
                try
                {
                    var textCommand = _commandReader.NextCommand();
                    if (textCommand == null) break;

                    var action = _actionParser.Parse(textCommand);
                    _commandFactory.Create(action.Type).Execute(action.Args);
                }
                catch (Exception e)
                {
                    _outputter.Write(e.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            var surface = new Bounds(new Point(0, 0), 5);
            var reader = new ConsoleCommandReader();
            var outputter = new ConsoleWriter();

            var app = new App(surface, reader, outputter);
            app.Run();
        }
    }
}
