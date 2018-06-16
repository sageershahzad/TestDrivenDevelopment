using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            BossEnemy bossEnemy = new BossEnemy();

            var sut = new PlayerCharacter();
            var items = sut.Weapons;

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            //bossEnemy.Display();
            GetTestData();
        }


        public static void GetTestData()
        {
            string[] csvLines = File.ReadAllLines(@"C:\Users\rudph\Documents\Visual Studio 2017\Project\Tests\UnitTestProjects\GameEngine\GameEngine.Tests\Damage.csv");
            

            foreach (var csvLine in csvLines)
            {
                Console.WriteLine(csvLine);
            }

            
        }
    }
}
