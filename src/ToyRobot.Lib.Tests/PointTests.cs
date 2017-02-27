using NUnit.Framework;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void CanAddToAnotherPoint()
        {
            var point1 = new Point(2, 3);
            var point2 = new Point(-1, 1);

            var result = point1 + point2;
            Assert.AreEqual(new Point(1, 4), result);
        }
    }
}
