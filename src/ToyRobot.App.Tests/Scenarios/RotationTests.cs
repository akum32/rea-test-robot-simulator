using NUnit.Framework;

namespace ToyRobot.App.Tests.Scenarios
{
    [TestFixture]
    public class RotationTests
    {
        [Test]
        public void CannotRotateUntilPlacedOnSurface()
        {
            var report = AppRunner.Execute(
                "LEFT",                
                "LEFT",
                "REPORT");

            Assert.IsNull(report);
        }

        [Test]
        public void CanFullyRotateLeft()
        {
            var report = AppRunner.Execute(
                "PLACE 0,0,NORTH",
                "LEFT",
                "LEFT",
                "LEFT",
                "LEFT",
                "LEFT",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,WEST"));
        }

        [Test]
        public void CanFullyRotateRight()
        {
            var report = AppRunner.Execute(
                "PLACE 0,0,NORTH",
                "RIGHT",
                "RIGHT",
                "RIGHT",
                "RIGHT",
                "RIGHT",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,EAST"));
        }
    }
}
