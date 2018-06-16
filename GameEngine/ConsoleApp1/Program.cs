using System;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
           TakeDamage(3);
            var rndi = CalculateHealthIncrease();
            Console.WriteLine(rndi);
        }
        public static int Health { get; set; } = 100;

        public static void TakeDamage(int damage)
        {
            int number = 0;

            Health = Math.Max(number, Health -= damage);

            Console.WriteLine(Health);
        }

        private static int CalculateHealthIncrease()
        {
            var rnd = new Random();

            return rnd.Next(1, 101);
        }

    }
}
