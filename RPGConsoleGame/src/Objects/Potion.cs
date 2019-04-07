using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Objects
{
    class Potion : AObject
    {
        public Potion(string name, int healthModifier = 20, int manaModifier = 0)
        {
            _name = name;
            _healthModifier = healthModifier;
            _manaModifier = manaModifier;
        }

        public override void Use(ref Fighters.AFighter target)
        {
            target.Life += _healthModifier;
            target.Mana += _manaModifier;
        }

        public override string ToString()
        {
            return _name + " to heal " + _healthModifier + " HealPoints";
        }
    }
}
