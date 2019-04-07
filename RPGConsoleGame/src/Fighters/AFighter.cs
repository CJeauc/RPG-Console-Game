using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Fighters
{
    abstract class AFighter
    {
        /*----- Delegates and Events -----*/
        public delegate void FighterDiedEventHandler(string winnerName, string looserName);

        public static event EventHandler<AFighter> Attacked;
        public static event EventHandler<int> Damaged;
        public static event EventHandler<Objects.AObject> UsedObject;
        public static event EventHandler<Spells.ASpell> UsedSpell;
        public static event FighterDiedEventHandler FighterDied;

        /*----- Field -----*/
        protected static readonly Random _random = new Random();

        protected string _name;
        protected uint _initiative;

        protected int _maxHealthPoint;
        protected int _healthPoint;
        protected int _maxManaPoint;
        protected int _manaPoint;

        protected int _attack;
        protected int _defense;

        protected Weapons.AWeapon _weapon;

        protected List<Objects.AObject> _objects;

        /*----- Constuctor / Getter / Setter -----*/
        public AFighter(int initiative = -1, int minInitiative = 0)
        {
            _initiative = initiative < 0 ? (uint)_random.Next(minInitiative, minInitiative + 100) : (uint)initiative;
        }
        public string Name
        {
            get { return _name; }
        }

        public int Life
        {
            get { return _healthPoint; }
            set
            {
                _healthPoint = value;
                if (_healthPoint > _maxHealthPoint)
                    _healthPoint = _maxHealthPoint;
            }
        }

        public int Mana
        {
            get { return _manaPoint; }
            set
            {
                _manaPoint = value;
                if (_manaPoint > _maxManaPoint)
                    _manaPoint = _maxManaPoint;
            }
        }

        public int AttackValue
        {
            get { return _attack; }
        }

        public int Defense
        {
            get { return _defense; }
        }

        public uint Initiative
        {
            get { return _initiative; }
        }

        public abstract void Attack(AFighter target);

        /*----- Virutal Methodes -----*/
        public virtual void Update()
        {
        }

        public virtual void TakeDamage(int damage)
        {
            _healthPoint -= damage;
            if (_healthPoint <= 0)
                _healthPoint = 0;
            OnDamaged(damage);
        }

        /*----- Events Methodes -----*/
        protected virtual void OnAttacked(AFighter target)
        {
            Attacked?.Invoke(this, target);
        }

        protected virtual void OnDamaged(int damage)
        {
            Damaged?.Invoke(this, damage);
        }

        protected virtual void OnUsedObject(Objects.AObject obj)
        {
            UsedObject?.Invoke(this, obj);
        }

        protected virtual void OnUsedSpell(Spells.ASpell spell)
        {
            UsedSpell?.Invoke(this, spell);
        }

        protected virtual void OnFighterDied(AFighter opponent)
        {
            if (opponent.Life <= 0)
                FighterDied?.Invoke(_name, opponent.Name);
            else if (_healthPoint <= 0)
                FighterDied?.Invoke(opponent.Name, _name);
        }

        /*----- Methodes -----*/
        protected void UseObject(int objectId, AFighter target)
        {
            if (_objects != null && _objects.Count > 0)
            {
                if (objectId < 0)
                {
                    _objects.First().Use(ref target);
                    OnUsedObject(_objects.First());
                    _objects.RemoveAt(0);
                }
                else if (objectId < _objects.Count)
                {
                    _objects[objectId].Use(ref target);
                    OnUsedObject(_objects[objectId]);
                    _objects.RemoveAt(objectId);
                }
            }
        }

        /*----- Override Methodes -----*/
        public override string ToString()
        {
            return _name;
        }
    }
}