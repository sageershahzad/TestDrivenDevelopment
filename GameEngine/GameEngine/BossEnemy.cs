using System;

namespace GameEngine
{
    public class BossEnemy : Enemy
    {
        public override double TotalSpecialPower => 1000;
        public override double SpecialPowerUses => 6;
       
        //public override double Display()
        //{
        //    double value = Math.Round(SpecialAttackPower, 1);
        //    return value;
        //}
    }
}
