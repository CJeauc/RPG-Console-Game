using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Weapons
{
    class Sword : AWeapon
    {
        public Sword(string name = "Sword", int damage = 15, uint durability = 100)
        {
            _name = name;
            _damage = damage;
            _durability = durability;
        }
    }
}
