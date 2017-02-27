using NUnit.Framework;
using Moq;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class InitialisedStateTests
    {
        private Mock<IRobotReporter> _mockReporter;
        private Mock<ICompass> _mockCompass;
        private Mock<IDirection> _mockDirection;

        [SetUp]
        public void Setup()
        {
            _mockReporter = new Mock<IRobotReporter>();
            _mockCompass = new Mock<ICompass>();
            _mockDirection = new Mock<IDirection>();
            _mockCompass.SetupGet(m => m.Facing).Returns(_mockDirection.Object);
        }

        [Test]
        public void CanMoveInTheCurrentCompassDirectionIfWihinSurfaceBounds()
        {
            var state = CreateState(bounds: new Bounds(3), coordinates: new Point(1, 1));
            _mockDirection.SetupGet(m => m.Offset).Returns(new Point(1, 0));

            state.Move();
            Assert.AreEqual(new Point(2, 1), state.Coordinates);
        }

        [Test]
        public void CannotMoveInTheCurrentCompassDirectionIfOutsideOfSurfaceBounds()
        {
            var state = CreateState(bounds: new Bounds(3), coordinates: new Point(2, 2));
            _mockDirection.SetupGet(m => m.Offset).Returns(new Point(1, 0));

            state.Move();
            Assert.AreEqual(new Point(2, 2), state.Coordinates);
        }

        [Test]
        public void CanRotateLeftUsingCompass()
        {
            var state = CreateState();
            state.RotateLeft();
            _mockCompass.Verify(m => m.Left(), Times.Once);
        }

        [Test]
        public void CanRotateRightUsingCompass()
        {
            var state = CreateState();            
            state.RotateRight();
            _mockCompass.Verify(m => m.Right(), Times.Once);
        }

        [Test]
        public void CanReportUsingReporter()
        {
            var state = CreateState(coordinates: new Point(2, 2));
            _mockCompass.Setup(m => m.Facing).Returns(_mockDirection.Object);

            state.Report();
            _mockReporter.Verify(m => m.Report(new Point(2, 2), _mockDirection.Object));
        }

        private InitialisedState CreateState(
            Bounds bounds = new Bounds(), Point coordinates = new Point())
        {
            return new InitialisedState(bounds, coordinates, _mockCompass.Object, _mockReporter.Object);
        }
    }
}
