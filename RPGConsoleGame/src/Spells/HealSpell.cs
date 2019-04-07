using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Spells
{
    class HealSpell : ASpell
    {
        public HealSpell(string name = "Healing wave", int healthModifier = 30, int manaModifier = 5)
        {
            _name = name;
            _healthModifier = healthModifier;
            _manaModifier = manaModifier;
        }

        public override void Use(Fighters.AFighter target)
        {
            target.Life += _healthModifier;
        }

        public override string ToString()
        {
            return _name + " to heal " + _healthModifier + " HealPoints";
        }
    }
}
