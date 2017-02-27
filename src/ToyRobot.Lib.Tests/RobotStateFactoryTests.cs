using NUnit.Framework;
using Moq;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class RobotStateFactoryTests
    {
        [Test]
        public void CanCreateUninitialisedRobotState()
        {
            var reporter = new Mock<IRobotReporter>().Object;
            var factory = new RobotStateFactory(reporter);
            var obj = factory.UninitialisedState();
            Assert.IsInstanceOf<UnInitialisedState>(obj);
        }

        [Test]
        public void CanCreateInitialisedRobotState()
        {
            var surface = new Bounds();
            var coordinates = new Point();
            const string facing = "NORTH";

            var reporter = new Mock<IRobotReporter>().Object;
            var factory = new RobotStateFactory(reporter);
            var obj = factory.InitialisedState(surface, coordinates, facing);

            Assert.IsInstanceOf<InitialisedState>(obj);
            var state = (InitialisedState) obj;
            Assert.AreEqual(surface, state.Surface);
            Assert.AreEqual(coordinates, state.Coordinates);
            Assert.AreEqual(reporter, state.Reporter);
            Assert.AreEqual(facing, state.Compass.Facing.Name);
        }
    }
}
