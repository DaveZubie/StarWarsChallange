using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsChallenge;

namespace UnitTestProject
{
    [TestClass]
    public class HoursTillResupplyUnitTests
    {
        [TestMethod]
        public void UnknownConsumableTests()
        {
            Ship ship = new Ship("ShipName", "1", "unknown");
            Assert.AreEqual(0, ship.Consumables);
        }

        [TestMethod]
        public void InvalidConsumableTest()
        {
            Ship ship = new Ship("ShipName", "1", "gghghgh");
            Assert.AreEqual(0, ship.Consumables);
        }

        [TestMethod]
        public void InvalidConsumableTimePeriosTest()
        {
            Ship ship = new Ship("ShipName", "1", "5 does");
            Ship ship2 = new Ship("ShipName", "1", "5 does again");

            Assert.AreEqual(0, ship.Consumables);
            Assert.AreEqual(0, ship2.Consumables);
        }

        [TestMethod]
        public void negativeTimeTest()
        {
            Ship ship = new Ship("ShipName", "1", "-1 hour");

            Assert.AreEqual(0, ship.Consumables);
        }

        [TestMethod]
        public void validHoursTest()
        {
            Ship ship = new Ship("ShipName", "1", "1 hour");
            Ship ship2 = new Ship("ShipName", "1", "26 hours");

            Assert.AreEqual(1, ship.Consumables);
            Assert.AreEqual(26, ship2.Consumables);
        }

        [TestMethod]
        public void validDaysTest()
        {
            Ship ship = new Ship("ShipName", "1", "1 day");
            Ship ship2 = new Ship("ShipName", "1", "7 days");

            Assert.AreEqual(24, ship.Consumables);
            Assert.AreEqual(168, ship2.Consumables);
        }

        [TestMethod]
        public void validWeeksTest()
        {
            Ship ship = new Ship("ShipName", "1", "1 week");
            Ship ship2 = new Ship("ShipName", "1", "4 weeks");

            Assert.AreEqual(168, ship.Consumables);
            Assert.AreEqual(672, ship2.Consumables);
        }

        [TestMethod]
        public void validMonthsTest()
        {
            Ship ship = new Ship("ShipName", "1", "1 month");
            Ship ship2 = new Ship("ShipName", "1", "12 months");

            Assert.AreEqual(720, ship.Consumables);
            Assert.AreEqual(8640, ship2.Consumables);
        }

        [TestMethod]
        public void validYearsTest()
        {
            Ship ship = new Ship("ShipName", "1", "1 year");
            Ship ship2 = new Ship("ShipName", "1", "5 years");

            Assert.AreEqual(8760, ship.Consumables);
            Assert.AreEqual(43800, ship2.Consumables);
        }
    }
}
