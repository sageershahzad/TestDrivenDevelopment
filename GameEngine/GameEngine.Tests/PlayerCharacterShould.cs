using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
   public class PlayerCharacterShould
    {
         PlayerCharacter sut;

        [TestInitialize]

        public void TestInitialize()
        {
            sut = new PlayerCharacter
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void BeInexperiencedWhenNew()
        {
           
             
            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        public void ListOfStartingWeaponsDefaultsTest()
        {
             
            var items = sut.Weapons;

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            var expected = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(expected, sut.Weapons);

        }


        [TestMethod]
        [TestCategory("Player Defaults")]
        [Ignore("Temporarily Disabled For Refactoring")]
        public void NotHaveNickNameByDefault()
        {
             
                       var actual = sut.Nickname;

            Assert.AreEqual("Khano", actual);
        }

        [DataTestMethod]
        [TestCategory("Player Defaults")]
        [Ignore]
        public void StartWithDefaultHealth()
        {
             

            Assert.AreEqual(100, sut.Health);
        }

      

        [TestMethod]
      [DynamicData(nameof(ExternalHealthDamageTestData.GetTestData), 
            typeof(ExternalHealthDamageTestData), DynamicDataSourceType.Method)]
       [TestCategory("Player Health DDT")]
        public void TakeDamageTest(int damage, int expectedHealth)
        {
             

            sut.TakeDamage(damage);

            var expected = expectedHealth;

            var actual = sut.Health;

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamageTest_1()
        {
             
            sut.TakeDamage(1);
            var expected = 99;
            var actual = sut.Health;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamageTest_0()
        {
             
            sut.TakeDamage(0);
            var expected = 100;
            var actual = sut.Health;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamageTest_100()
        {
             
            sut.TakeDamage(100);
            var expected = 1;
            var actual = sut.Health;
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamageTest_101()
        {
             
            sut.TakeDamage(101);
            var expected = 1;
            var actual = sut.Health;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamageTest_50()
        {
             
            sut.TakeDamage(50);
            var expected = 50;
            var actual = sut.Health;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void IncreaseHealthAfterSleep()
        {
            sut.Sleep();
            //Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200); 
            Assert.That.IsInRange(sut.Health, 101, 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
          
            Assert.AreEqual("Sarah Smith", sut.FullName);
        }

        [TestMethod]
        public void HaveFullNameStartsWithFirstName()
        {
            StringAssert.StartsWith(sut.FullName, "Sarah");
        }

        [TestMethod]
        public void IgnoreCaseFullName()
        {
            Assert.AreEqual("SARAH SMITH", sut.FullName, true);
        }


        [TestMethod]
        public void HaveFullNameEndsWithLastName()
        {

            Assert.IsTrue(sut.FullName.EndsWith("Smith"));
        }

        [TestMethod]
        public void CalculateFullName_Contains()
        {
            StringAssert.Contains(sut.FirstName, "ra");
        }


        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void PlayerHaveLongBow()
        {
             CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void PlayerDoesNotHaveStaffOfWonder()
        {
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
             
            var expected = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(expected, sut.Weapons);
        }


        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
             
            var expected = new[]
            {
                "Long Bow",
                "Short Sword",
                "Short Bow"
            };

            CollectionAssert.AreEquivalent(expected, sut.Weapons);
        }

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
             
            var expected = new[]
            {
                "Long Bow",
                "Short Sword",
                "Short Bow"
            };

            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtleastOneKindOfSowrd()
        {
             
            var expected = new[]
            {
                "Long Bow",
                "Short Sword",
                "Short Bow"
            };

            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapon()
        {
           //Assert.IsFalse(sut.Weapons.Any(string.IsNullOrWhiteSpace));
           CollectionAssert.That.AllItemsNotNullOrWhiteSpace(sut.Weapons);
           CollectionAssert.That.AllItemsSatisfy(sut.Weapons, weapon => !string.IsNullOrWhiteSpace(weapon));
        }
    }
}

