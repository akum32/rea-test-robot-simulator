using NUnit.Framework;
using ToyRobot.Lib;

namespace ToyRobot.App.Tests.Scenarios
{
    [TestFixture]
    public class Movement
    {
        private readonly Bounds _singleBounds = new Bounds(new Point(0,0), 1);

        [Test]
        public void CannotMoveUntilPlacedOnSurface()
        {
            var report = AppRunner.Execute(
                "MOVE",
                "MOVE",
                "REPORT");

            Assert.IsNull(report);
        }

        [Test]
        public void CanMoveInAllDirectionsWithinSurfaceBounds()
        {
            var report = AppRunner.Execute(new Bounds(new Point(0,0), 2),
                "PLACE 0,0,WEST",
                "RIGHT",
                "MOVE",
                "RIGHT",
                "MOVE",
                "RIGHT",
                "MOVE",
                "RIGHT",
                "MOVE",
                "LEFT",
                "LEFT",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("1,0,EAST"));
        }

        [Test]
        public void CannotMoveNorthIfOutsideSurfaceBounds()
        {
            var report = AppRunner.Execute(_singleBounds,
                "PLACE 0,0,NORTH",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,NORTH"));
        }

        [Test]
        public void CannotMoveEastIfOutOfSurfaceBounds()
        {
            var report = AppRunner.Execute(_singleBounds,
                "PLACE 0,0,EAST",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,EAST"));
        }
        
        [Test]
        public void CannotMoveSouthIfOutOfSurfaceBounds()
        {
            var report = AppRunner.Execute(_singleBounds,
                "PLACE 0,0,SOUTH",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,SOUTH"));
        }
        
        [Test]
        public void CannotMoveWestIfOutOfSurfaceBounds()
        {
            var report = AppRunner.Execute(_singleBounds,
                "PLACE 0,0,WEST",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,WEST"));
        }
    }
}
