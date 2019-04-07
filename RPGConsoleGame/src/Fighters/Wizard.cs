using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Fighters
{
    class Wizard : AFighter
    {
        private List<Spells.ASpell> _spells;
        private bool _healingMode = false;

        public Wizard(string name = "Wizard",
            int initiative = -1, int maxHealth = 100,
            int maxMana = 50, int attack = 8, int defense = 8)
            : base(initiative, 20)

        {
            _name = name;
            _maxHealthPoint = maxHealth;
            _healthPoint = maxHealth;
            _maxManaPoint = maxMana;
            _manaPoint = maxMana;
            _attack = attack;
            _defense = defense;

            _weapon = new Weapons.Sword("Old Sword", attack);
            _spells = new List<Spells.ASpell>();
            _spells.Add(new Spells.AttackSpell());
            _spells.Add(new Spells.HealSpell());
        }

        public override void Attack(AFighter target)
        {
            if (_manaPoint >= _spells[0].ManaModifier)
            {
                if (_healingMode)
                {
                    UseSpell(1, this);
                }
                else
                {
                    UseSpell(0, target);
                    OnFighterDied(target);
                }
            }
            else
            {
                OnAttacked(target);

                int damage =
                    Math.Max((_attack + _random.Next(_attack)) - (target.Defense + _random.Next(target.Defense)), 0);

                _manaPoint += _random.Next(1, 3);
                target.TakeDamage(damage);
                OnFighterDied(target);
            }
        }

        private void UseSpell(int spellId, AFighter target)
        {
            if (_spells?[spellId] != null)
            {
                OnUsedSpell(_spells[spellId]);
                _spells[spellId].Use(target);
                _manaPoint -= _spells[spellId].ManaModifier;
            }
        }

        public override void Update()
        {
            base.Update();
            _healingMode = _healthPoint <= _maxHealthPoint / 4;
        }
    }
}