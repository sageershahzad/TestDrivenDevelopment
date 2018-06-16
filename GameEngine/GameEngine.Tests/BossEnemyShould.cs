using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class BossEnemyShould
    {
        [TestMethod]

        public void HaveCorrectSpecialAttackPower()
        {
            BossEnemy sut = new BossEnemy();
            var expected = 166.6;
            var actual = sut.SpecialAttackPower;

            Assert.AreEqual(expected, actual, 0.07);
        }
    }
}
