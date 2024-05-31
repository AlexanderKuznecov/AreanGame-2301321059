using ArenaGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Magician : Hero
    {
        private List<Spell> Spells { get; set; }
        private int roundCount;

        public Magician(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
            Spells = new List<Spell>
            {
                new Spell("Weak Spell 1") { AttackDamage = 25, BlockingPower = 1 },
                new Spell("Weak Spell 2") { AttackDamage = 30, BlockingPower = 1 },
                new Spell("Strong Spell") { AttackDamage = 40, BlockingPower = 1 },
                new Spell("Healing Spell") { AttackDamage = 0, BlockingPower = 1 }
            };
            roundCount = 0;
        }

        public override double Attack()
        {
            roundCount++;
            Spell spellToUse;

            if (roundCount % 3 == 0)
            {
                spellToUse = Spells[2]; 
            }
            else
            {
                spellToUse = Spells[random.Next(0, 2)]; 
            }

            double totalDamage = Strenght + spellToUse.AttackDamage;
            double coef = random.Next(80, 120 + 1);
            double realDamage = totalDamage * (coef / 100);
            return realDamage;
        }

        public void Heal()
        {
            if (roundCount % 4 == 0)
            {
                Spell healingSpell = Spells[3];
                double healAmount = 20; 
                Health += healAmount;
                Console.WriteLine($"{Name} used {healingSpell.Name} and healed {healAmount} health points.");
            }
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
