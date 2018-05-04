using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsChallenge;

namespace UnitTestProject
{
    [TestClass]
    public class ResuppliesRequiredUnitTests
    {
        [TestMethod]
        public void InvalidMGLTTest()
        {
            double distance = 100;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "0", "1 day");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(false, ship.ValidJump);
            Assert.AreEqual(-1, jumps);
        }

        [TestMethod]
        public void InvalidConsumablesTest()
        {
            double distance = 100;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "100", "0");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(false, ship.ValidJump);
            Assert.AreEqual(-1, jumps);
        }

        [TestMethod]
        public void InvalidMGLTAndConsumablesTest()
        {
            double distance = 100;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "0", "0");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(false, ship.ValidJump);
            Assert.AreEqual(-1, jumps);
        }
        
        [TestMethod]
        public void JumpToMaxConsumablesTest()
        {
            double distance = 100;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "100", "1 hour");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(true, ship.ValidJump);
            Assert.AreEqual(0, jumps);
        }

        [TestMethod]
        public void JumpTo10TimesMaxConsumablesTest()
        {
            double distance = 2400;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "10", "1 day");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(true, ship.ValidJump);
            Assert.AreEqual(9, jumps);
        }

        [TestMethod]
        public void JumpToJustUnderMaxConsumablesTest()
        {
            double distance = 99;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "100", "1 hour");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(true, ship.ValidJump);
            Assert.AreEqual(0, jumps);
        }

        [TestMethod]
        public void JumpToJustOverMaxConsumablesTest()
        {
            double distance = 101;
            int jumps = 0;
            Ship ship = new Ship("ShipName", "100", "1 hour");

            jumps = ship.ResuppliesRequired(distance);

            Assert.AreEqual(true, ship.ValidJump);
            Assert.AreEqual(1, jumps);
        }
    }
}
