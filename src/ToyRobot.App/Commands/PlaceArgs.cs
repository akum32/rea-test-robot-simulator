using ToyRobot.Lib;

namespace ToyRobot.App.Commands
{
    public struct PlaceArgs
    {
        public Point Coordinates;
        public string Facing;

        public PlaceArgs(Point coordinates, string facing)
        {
            Coordinates = coordinates;
            Facing = facing;
        }
    }
}
