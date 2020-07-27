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
        public void PlayerHealthIsSetCorrectly(string name, int health)
        {
            var player = new Player(name, health,10,10);
            string nameActual = "Test";
            int healthActual = 100;
            Assert.AreEqual(player.Name, nameActual);
            Assert.AreEqual(player.Health, healthActual);
        }

        [Test]
        public void PlayerCanAttackMonsterAndReportCorrectly()
        {
            var player = new Player("Test", 100, 10, 10);
            var monster = new Monster("TestMonster", 100, 10, 10);
            var expected = "Test attacks TestMonster dealing 10 damage";
            Assert.AreEqual(player.Attack(monster), expected);
        }

        [Test]
        public void PlayerCanAttackMonsterAndItDies()
        {
            var player = new Player("Test", 100, 10, 10);
            var monster = new Monster("TestMonster", 10, 10, 10);
            var expected = "Test attacks TestMonster and kills it!!!";
            Assert.AreEqual(player.Attack(monster), expected);

        }
    }
}