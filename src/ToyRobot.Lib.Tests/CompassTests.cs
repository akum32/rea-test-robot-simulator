using System;
using NUnit.Framework;

namespace ToyRobot.Lib.Tests
{
    [TestFixture]
    public class CompassTests
    {
        [Test]
        public void CanFaceNorth()
        {
            var c = new Compass("NORTH");
            Assert.AreEqual("NORTH", c.Facing.Name);
        }

        [Test]
        public void CanFaceEast()
        {
            var c = new Compass("EAST");
            Assert.AreEqual("EAST", c.Facing.Name);
        }

        [Test]
        public void CanFaceSouth()
        {
            var c = new Compass("SOUTH");
            Assert.AreEqual("SOUTH", c.Facing.Name);
        }

        [Test]
        public void CanFaceWest()
        {
            var c = new Compass("WEST");
            Assert.AreEqual("WEST", c.Facing.Name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotFaceAnUnsupportedDirection()
        {
           new Compass("INVALID");
        }

        [Test]
        public void CanCycleThroughDirectionsAntiClockwise()
        {
            var c = new Compass("NORTH");
            foreach (var direction in new[] { "WEST", "SOUTH", "EAST", "NORTH" })
            {
                c.Left();
                Assert.AreEqual(direction, c.Facing.Name);
            }
        }

        [Test]
        public void CanCycleThroughDirectionsClockwise()
        {
            var c = new Compass("NORTH");
            foreach (var direction in new[] { "EAST", "SOUTH", "WEST", "NORTH" })
            {
                c.Right();
                Assert.AreEqual(direction, c.Facing.Name);
            }
        }
    }
}
