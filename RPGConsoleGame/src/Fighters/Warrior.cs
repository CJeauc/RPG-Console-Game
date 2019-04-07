using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Fighters
{
    class Warrior : AFighter
    {
        public static event EventHandler<string> ActivatedShieldMode;

        private bool _isShieldMode = false;

        public Warrior(string name = "Warrior",
            int initiative = -1, int maxHealth = 200,
            int maxMana = 0, int attack = 15, int defense = 10)
            : base(initiative, 50)
        {
            _name = name;
            _maxHealthPoint = maxHealth;
            _healthPoint = maxHealth;
            _maxManaPoint = maxMana;
            _manaPoint = maxMana;
            _attack = attack;
            _defense = defense;

            _weapon = new Weapons.Sword("Sword", attack);
            _objects = new List<Objects.AObject>();
            _objects.Add(new Objects.Potion("HealPotion"));
            _objects.Add(new Objects.Potion("HealPotion"));
        }

        public override void Attack(AFighter target)
        {
            if (_healthPoint <= _maxHealthPoint / 4 && _objects.Count > 0)
            {
                UseObject(-1, this);
            }
            else
            {
                int damage =
                    Math.Max((_attack + _random.Next(_attack)) - (target.Defense + _random.Next(target.Defense)), 0);

                OnAttacked(target);

                if (target.Mana < 5)
                {
                    _isShieldMode = false;
                }
                else if (_healthPoint <= _maxHealthPoint / 2 || _isShieldMode)
                {
                    _isShieldMode = true;
                    OnActivatedShieldMode();
                    damage /= 2;
                }

                target.TakeDamage(damage);
                OnFighterDied(target);
            }
        }

        public override void Update()
        {
            base.Update();
            _isShieldMode = _healthPoint <= _maxHealthPoint / 2;
        }

        public override void TakeDamage(int damage)
        {
            if (_isShieldMode)
            {
                damage /= 2;
                OnActivatedShieldMode();
            }

            base.TakeDamage(damage);
        }

        protected virtual void OnActivatedShieldMode()
        {
            ActivatedShieldMode?.Invoke(this, _name);
        }
    }
}