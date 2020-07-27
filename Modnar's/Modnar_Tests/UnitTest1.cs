using NUnit.Framework;
using Modnar_Classes;
using NUnit.Framework.Constraints;

namespace Modnar_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase ("Test", 100)]
        public void Test1(string nameActual, int healthActual)
        {
            var player = new Player("Test", 100);
            
            Assert.AreEqual(player.name, nameActual);
            Assert.AreEqual(player.health, healthActual);
        }
    }
}