using NUnit.Framework;

namespace ToyRobot.App.Tests.Scenarios
{
    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void ExampleA()
        {
            var report = AppRunner.Execute(
                "PLACE 0,0,NORTH",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("0,1,NORTH"));
        }

        [Test]
        public void ExampleB()
        {
            var report = AppRunner.Execute(
                "PLACE 0,0,NORTH",
                "LEFT",
                "REPORT");

            Assert.IsTrue(report.Contains("0,0,WEST"));
        }

        [Test]
        public void ExampleC()
        {
            var report = AppRunner.Execute(
                "PLACE 1,2,EAST",
                "MOVE",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT");

            Assert.IsTrue(report.Contains("3,3,NORTH"));
        }
    }
}
