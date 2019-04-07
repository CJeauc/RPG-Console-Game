using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Spells
{
    class AttackSpell : ASpell
    {
        public AttackSpell(string name = "Fire Ball", int healthModifier = 20, int manaModifier = 5)
        {
            _name = name;
            _healthModifier = healthModifier;
            _manaModifier = manaModifier;
        }

        public override void Use(Fighters.AFighter target)
        {
            target.TakeDamage(_healthModifier + _random.Next(_healthModifier / 2));
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
