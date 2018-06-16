using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class EnemyFactoryShould
    {
        [TestMethod]
        public void NotAllowNullName()
        {
            //System Under Test
            EnemyFactory sut = new EnemyFactory();

            Assert.ThrowsException<ArgumentNullException>(() => sut.Create(null));
        }


        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            //System Under Test
            EnemyFactory sut = new EnemyFactory();

           // Assert.ThrowsException<EnemyCreationException>((() => sut.Create("Super", true)));

            EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>((() => sut.Create("Super", true)));
           Assert.AreEqual("Super", ex.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Jombie");

            Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));
        }

        [TestMethod]
        public void CreateBossEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Superr King", true);

            Assert.IsInstanceOfType(enemy, typeof(BossEnemy));
            
        }

        [TestMethod]
        public void SeprateEnemyInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombaie");
            Enemy enemy2 = sut.Create("Zombaie");

            Assert.AreNotSame(enemy1, enemy2);
        }
    }
}
