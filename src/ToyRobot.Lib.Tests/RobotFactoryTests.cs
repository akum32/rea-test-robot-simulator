using NUnit.Framework;
using Moq;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class RobotFactoryTests
    {
        [Test]
        public void CanCreateRobot()
        {
            var reporter = new Mock<IRobotReporter>().Object;
            var factory = new RobotFactory(reporter);
            var obj = factory.Create();

            Assert.IsInstanceOf<Robot>(obj);
            var robot = (Robot) obj;
            Assert.IsInstanceOf<RobotStateFactory>(robot.StateFactory);
            Assert.AreEqual(reporter, ((RobotStateFactory) robot.StateFactory).Reporter);
        }
    }
}
