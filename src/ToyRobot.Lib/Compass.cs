using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobot.Lib
{
    public interface ICompass
    {
        IDirection Facing { get; }

        void Left();
        void Right();
    }

    public class Compass : ICompass
    {
        public IDirection Facing { get { return _facing.Value; } }
        private LinkedListNode<IDirection> _facing;

        private readonly LinkedList<IDirection> _directions = new LinkedList<IDirection>(
            new[]
                {
                    new Direction("NORTH", new Point(0, 1)),
                    new Direction("EAST", new Point(1, 0)),
                    new Direction("SOUTH", new Point(0, -1)),
                    new Direction("WEST", new Point(-1, 0))
                });

        public Compass(string direction)
        {
            SetDirection(direction);
        }

        public void Left()
        {
            _facing = (_facing.Previous ?? _directions.Last);
        }

        public void Right()
        {
            _facing = (_facing.Next ?? _directions.First);
        }

        private void SetDirection(string direction)
        {
            var obj = _directions.SingleOrDefault(d => d.Name == direction.ToUpper());
            if (obj == null) throw new ArgumentException(string.Format("Direction '{0}' invalid!", direction));
            _facing = _directions.Find(obj);
        }
    }
}
