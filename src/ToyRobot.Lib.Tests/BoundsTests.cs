using NUnit.Framework;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class BoundsTests
    {
        [Test]
        public void CanDetermineEndpointBasedOnLength()
        {
            var bounds = new Bounds(new Point(0,0), 5);
            var end = bounds.End;            
            Assert.AreEqual(4, end.X);
            Assert.AreEqual(4, end.Y);
        }

        [Test]
        public void ContainsPointIfWithinBounds()
        {
            var bounds = new Bounds(new Point(0,0), 2);
            
            Assert.IsTrue(bounds.Contains(new Point(0,0)));
            Assert.IsTrue(bounds.Contains(new Point(0,1)));
            Assert.IsTrue(bounds.Contains(new Point(1,0)));
            Assert.IsTrue(bounds.Contains(new Point(1,1)));
        }

        [Test]
        public void DoesNotContainPointIfOutOfBounds()
        {
            var bounds = new Bounds(new Point(0, 0), 1);

            Assert.IsFalse(bounds.Contains(new Point(-1, -1)));
            Assert.IsFalse(bounds.Contains(new Point(-1, 0)));
            Assert.IsFalse(bounds.Contains(new Point(-1, 1)));
            Assert.IsFalse(bounds.Contains(new Point(0, 1)));
            Assert.IsFalse(bounds.Contains(new Point(1, 1)));
            Assert.IsFalse(bounds.Contains(new Point(1, 0)));
            Assert.IsFalse(bounds.Contains(new Point(1, -1)));
            Assert.IsFalse(bounds.Contains(new Point(0, -1)));
        }
    }
}
