using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Tank : Hero
    {
        private int attackCount;
        private double spikedDamage;
        private int roundCount;

        public Tank(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
            attackCount = 0;
            spikedDamage = 12;
            roundCount = 0;
        }

        public override double Attack()
        {
            double totalDamage = Strenght + Weapon.AttackDamage;
            double coef = random.Next(80, 121);
            double realDamage = totalDamage * (coef / 100);

            attackCount++;

            if (attackCount % 2 == 0)
            {
                realDamage += spikedDamage;
            }

            roundCount++;

            return realDamage;
        }

        public override double Defend(double damage)
        {
            double coef = random.Next(80, 121);
            double blockingPower = Weapon.BlockingPower + (roundCount + 0.5);
            double defendPower = (Armor + blockingPower) * (coef / 100);
            double realDamage = damage - defendPower;

            if (realDamage < 0)
                realDamage = 0;

            Health -= realDamage;

            return realDamage;
        }
    }
}
