namespace ToyRobot.Lib
{
    public struct Bounds
    {
        public Point Start;
        public Point End;

        public Bounds(int length)
            : this(new Point(0, 0), length)
        {
        }

        public Bounds(Point start, int length)
        {
            Start = start;
            length--;
            var endX = start.X + length;
            var endY = start.Y + length;
            End = new Point(endX, endY);
        }

        public bool Contains(Point point)
        {
            return point.X >= Start.X && point.X <= End.X
                && point.Y >= Start.Y && point.Y <= End.Y;
        }
    }
}
