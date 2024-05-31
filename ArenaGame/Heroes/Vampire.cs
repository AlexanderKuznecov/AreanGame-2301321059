using ArenaGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Vampire : Hero
    {
        private double bloodDMG;
        private double maxBloodDMG;
        public Vampire(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
            bloodDMG = 0;
            maxBloodDMG = 100;
        }

        public override double Attack()
        {
            double totalDamage = Strenght + Weapon.AttackDamage;
            double coef = random.Next(80, 121);
            double realDamage = totalDamage * (coef / 100);


            bloodDMG += 15;

            if (bloodDMG > maxBloodDMG)
            {
                bloodDMG = maxBloodDMG;
            }

            return realDamage + bloodDMG;
        }

        public void Heal()
        {
                double healAmount = 5;
                Health += healAmount;
                Console.WriteLine($"{Name} used blood suck and healed {healAmount} health points.");
        }

        public override double Defend(double damage)
        {
            double coef = random.Next(80, 120 + 1);
            double defendPower = Armor * (coef / 100);
            double realDamage = damage - defendPower;
            if (realDamage < 0)
                realDamage = 0;
            Health -= realDamage;
            Heal();
            return realDamage;
        }
    }
}
