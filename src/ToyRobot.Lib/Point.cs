namespace ToyRobot.Lib
{
    public struct Point
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point point1, Point point2)
        {
            var x = point1.X + point2.X;
            var y = point1.Y + point2.Y;
            return new Point(x, y);
        }
    }
}
