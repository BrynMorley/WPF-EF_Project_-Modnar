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
            var player = new Player("Test", 100,10,10);
            
            Assert.AreEqual(player.Name, nameActual);
            Assert.AreEqual(player.Health, healthActual);
        }
    }
}