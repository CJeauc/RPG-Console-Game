using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Spells
{
    abstract class ASpell
    {
        protected Random _random = new Random();
        protected string _name;
        protected int _healthModifier;
        protected int _manaModifier;

        public int ManaModifier
        {
            get { return _manaModifier; }
        }

        public int HealModifier
        {
            get { return _manaModifier; }
        }

        public abstract void Use(Fighters.AFighter target);

        public string Name
        {
            get { return _name; }
        }
    }
}
