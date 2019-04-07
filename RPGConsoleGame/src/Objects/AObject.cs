using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Objects
{
    abstract class AObject
    {
        protected string _name;
        protected int _healthModifier;
        protected int _manaModifier;

        public abstract void Use(ref Fighters.AFighter target);

        public string Name
        {
            get { return _name; }
        }

        public int HealthModifier
        {
            get { return _healthModifier; }
        }
    }
}
