using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.Fighters
{
    class Commentator
    {
        private bool _writeTop = false;

        public Commentator()
        {
            //  subscribe to all events
            AFighter.Attacked += this.OnAttacked;
            AFighter.Damaged += this.OnDamaged;
            AFighter.UsedObject += this.OnUsedObject;
            AFighter.UsedSpell += this.OnUsedSpell;
            AFighter.FighterDied += this.OnFighterDied;
            Warrior.ActivatedShieldMode += this.OnActivatedShieldMode;
            GameStates.PlayingState.IsPoped += this.OnIsPoped;
        }

        public void InverseWriteSide()
        {
            _writeTop = !_writeTop;
        }

        private void OnAttacked(object source, object target) // subscriber 1
        {
            string message = source.ToString() + " attacked " + target.ToString();
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + (_writeTop ? 0 : 10));
            Console.WriteLine(message);
        }

        private void OnUsedSpell(object source, Spells.ASpell spell) // subscriber 2
        {
            string message = source.ToString() + " used " + spell.ToString();
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + 1 + (_writeTop ? 0 : 10));
            Console.WriteLine(message);
        }

        private void OnActivatedShieldMode(object source, string args) // subscriber 3
        {
            string message = args + " used his shield";
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + 2 + (_writeTop ? 0 : 10));
            Console.WriteLine(message);
        }

        private void OnDamaged(object source, int damage) // subscriber 4
        {
            string message = source.ToString() + " get hit for " + damage;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + 3 + (_writeTop ? 0 : 10));
            Console.WriteLine(message);
        }

        private void OnUsedObject(object source, Objects.AObject obj) // subscriber 5
        {
            string message = source.ToString() + " used " + obj.ToString();
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + 4 + (_writeTop ? 0 : 10));
            Console.WriteLine(message);
        }

        private void OnFighterDied(string winnerName, string looserName) // subscriber 6
        {
            string message = looserName + " get deadly hit, the fight is over !!!\n\n";

            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + 6 + (_writeTop ? 0 : 10));
            Console.WriteLine(message);

            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2,
                Console.WindowHeight / 2 + 6 + (_writeTop ? 1 : 11));
            Console.WriteLine("\t" + winnerName + " his our winner !!");
        }

        private void OnIsPoped(object sender, EventArgs e) // subscriber 
        {
            // Unsubscribe to all events
            AFighter.Attacked -= this.OnAttacked;
            AFighter.Damaged -= this.OnDamaged;
            AFighter.UsedObject -= this.OnUsedObject;
            AFighter.UsedSpell -= this.OnUsedSpell;
            AFighter.FighterDied -= this.OnFighterDied;
            Warrior.ActivatedShieldMode -= this.OnActivatedShieldMode;
            GameStates.PlayingState.IsPoped -= this.OnIsPoped;
        }
    }
}