using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Hunter : Hero
    {
        private int arrowCount;
        private double poisonDamage;
        private Random random;
        public Hunter(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
            arrowCount = 0;
            poisonDamage = 20; 
            random = new Random();
        }

        public override double Attack()
        {
            double totalDamage = Strenght + Weapon.AttackDamage;
            double coef = random.Next(80, 121);
            double realDamage = totalDamage * (coef / 100);

            arrowCount++;

            if (arrowCount % 2 == 0)
            {
                realDamage += poisonDamage;
            }

            return realDamage;
        }
    }
}
