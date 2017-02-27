using NUnit.Framework;
using Moq;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class RobotTests
    {
        private Mock<IRobotStateFactory> _mockStateFactory;
        private Mock<IRobotState> _mockState;

        [SetUp]
        public void Setup()
        {
            _mockStateFactory = new Mock<IRobotStateFactory>();
            _mockState = new Mock<IRobotState>();
        }

        [Test]
        public void DefaultsToUninitialisedStateWhenCreated()
        {
            _mockStateFactory.Setup(m => m.UninitialisedState()).Returns(_mockState.Object);
            var robot = new Robot(_mockStateFactory.Object);
            Assert.AreEqual(_mockState.Object, robot.State);
        }

        [Test]
        public void ChangesToInitialisedStateWhenIntialised()
        {
            var surface = new Bounds();
            var coordinates = new Point();
            const string facing = "";

            _mockStateFactory.Setup(m => m.InitialisedState(surface, coordinates, facing)).Returns(_mockState.Object);
            
            var robot = new Robot(_mockStateFactory.Object);
            robot.Initialise(surface, coordinates, facing);
            Assert.AreEqual(_mockState.Object, robot.State);
        }

        [Test]
        public void MovesUsingCurrentState()
        {
            _mockStateFactory.Setup(m => m.UninitialisedState()).Returns(_mockState.Object);
            new Robot(_mockStateFactory.Object).Move();
            _mockState.Verify(m => m.Move());
        }

        [Test]
        public void RotatesRightUsingCurrentState()
        {
            _mockStateFactory.Setup(m => m.UninitialisedState()).Returns(_mockState.Object);
            new Robot(_mockStateFactory.Object).RotateRight();
            _mockState.Verify(m => m.RotateRight());
        }

        [Test]
        public void RotatesLeftUsingCurrentState()
        {
            _mockStateFactory.Setup(m => m.UninitialisedState()).Returns(_mockState.Object);
            new Robot(_mockStateFactory.Object).RotateLeft();
            _mockState.Verify(m => m.RotateLeft());
        }

        [Test]
        public void ReportsUsingCurrentState()
        {
            _mockStateFactory.Setup(m => m.UninitialisedState()).Returns(_mockState.Object);
            new Robot(_mockStateFactory.Object).Report();
            _mockState.Verify(m => m.Report());
        }
    }
}
