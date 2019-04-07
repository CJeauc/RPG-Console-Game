using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Weapons
{
    abstract class AWeapon
    {
        protected string _name;
        protected int _damage;
        protected uint _durability;

        public int Damages
        {
            get { return _damage; }
        }
    }
}
