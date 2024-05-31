using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class SpikedShield : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; set; }

        public SpikedShield(string name)
        {
            Name = name;
            AttackDamage = 3;
            BlockingPower = 30;
        }
    }
}
