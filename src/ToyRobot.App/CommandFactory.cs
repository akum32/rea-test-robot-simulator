using System;
using System.Collections.Generic;
using ToyRobot.App.Commands;
using ToyRobot.Lib;

namespace ToyRobot.App
{
    public interface ICommandFactory
    {
        ICommand Create(string command);
    }

    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<string, ICommand> _commands;

        public CommandFactory(ISimulator simulator)
        {
            _commands = new Dictionary<string, ICommand>
                            {
                                {"PLACE", new PlaceCommand(simulator)},
                                {"MOVE", new MoveCommand(simulator)},
                                {"LEFT", new RotateLeftCommand(simulator)},
                                {"RIGHT", new RotateRightCommand(simulator)},
                                {"REPORT", new ReportCommand(simulator)}
                            };
        }

        public ICommand Create(string action)
        {
            action = action.ToUpper();

            if( _commands.ContainsKey(action))
                return _commands[action];

            throw new ArgumentException(string.Format("Action {0} invalid!", action));
        }
    }
}
