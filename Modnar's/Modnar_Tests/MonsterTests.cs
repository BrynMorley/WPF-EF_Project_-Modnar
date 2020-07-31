using NUnit.Framework;
using Modnar_Classes;
using NUnit.Framework.Constraints;
using Modnar_Model;

namespace Modnar_Tests
{
    class MonsterTests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void MonsterCanAttackOtherIAttackables()
        {
            Monster monster = new Monster("monster",1,1,1);
            Monster targetMonster = new Monster("target monster",1,1,1);
            Player targetPlayer = new Player("target player",1,1,1,1);
            string expected1 = "monster attacks target monster and kills it!!!";
            string expected2 = "monster attacks target player and kills it!!!";

            Assert.AreEqual(monster.Attack(targetMonster),expected1);
            Assert.AreEqual(monster.Attack(targetPlayer), expected2);
        }
    }
}
