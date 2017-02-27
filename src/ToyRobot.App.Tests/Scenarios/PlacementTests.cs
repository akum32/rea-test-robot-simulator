using NUnit.Framework;
using ToyRobot.Lib;

namespace ToyRobot.App.Tests.Scenarios
{
    [TestFixture]
    public class PlacementTests
    {
        [Test]
        public void CannotPlaceIfCoordinatesOutsideSurfaceBounds()
        {
            var bounds = new Bounds(new Point(0, 0), 1);
            
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE -1,-1,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE -1,0,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE -1,1,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE 0,1,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE 1,1,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE 1,0,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE 1,-1,NORTH", "REPORT"));
            Assert.IsNull(AppRunner.Execute(bounds, "PLACE 0,-1,NORTH", "REPORT"));
        }

        [Test]
        public void CanPlaceInAnyDirectionIfCoordinatesWithinSurfaceBounds()
        {
            var bounds = new Bounds(new Point(0, 0), 1);

            Assert.IsTrue(AppRunner.Execute(bounds, "PLACE 0,0,NORTH", "REPORT").Contains("0,0,NORTH"));
            Assert.IsTrue(AppRunner.Execute(bounds, "PLACE 0,0,EAST", "REPORT").Contains("0,0,EAST"));
            Assert.IsTrue(AppRunner.Execute(bounds, "PLACE 0,0,SOUTH", "REPORT").Contains("0,0,SOUTH"));
            Assert.IsTrue(AppRunner.Execute(bounds, "PLACE 0,0,WEST", "REPORT").Contains("0,0,WEST"));
        }
    }
}
