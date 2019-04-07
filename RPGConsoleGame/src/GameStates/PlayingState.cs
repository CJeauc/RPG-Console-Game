using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_PGP_2021.src.Fighters;

namespace RPG_PGP_2021.src.GameStates
{
    class PlayingState : AGameState
    {
        public static event EventHandler IsPoped;

        private Commentator _commentator;
        private List<AFighter> _fighters = new List<AFighter>();

        public PlayingState(AFighter firstFighter, AFighter secondFighter)
        {
            _fighters.Add(firstFighter);
            _fighters.Add(secondFighter);
            _fighters = _fighters.OrderByDescending(y => y.Initiative).ThenBy(y => y.AttackValue).ToList();

            AFighter.FighterDied += this.OnEndGame;
            _commentator = new Commentator();
        }

        public override void DrawHUD()
        {
            base.DrawHUD();
            DrawFighterInfo(true);
        }

        public override void HandleInput()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.KeyChar == 'q' || key.KeyChar == 27) // 27 is escape key
            {
                this.OnEndGame();
            }
        }

        public override void Update()
        {
            for (int i = 0; i < _fighters.Count; ++i)
            {
                _commentator.InverseWriteSide();

                _fighters[i].Attack(_fighters[(i + 1) < _fighters.Count ? i + 1 : 0]);

                _fighters[i].Update();
            }

            DrawFighterInfo(false);
        }

        public void AddFighter(AFighter fighter)
        {
            _fighters.Add(fighter);
            _fighters = _fighters.OrderBy(y => y.Initiative).ThenBy(y => y.AttackValue).ToList();
        }

        private void OnEndGame(string winnerName = null, string looserName = null)
        {
            OnIsPoped();
            OnMustPop();
            OnAddState(new GameOverState(winnerName, looserName));
        }

        private void DrawFighterInfo(bool writeTop = true)
        {
            DrawFightersInfoLeft(0, writeTop);
            DrawFightersInfoRight(1, writeTop);
        }

        private void DrawFightersInfoLeft(int id, bool writeTop = true)
        {
            Console.SetCursorPosition(12, Console.WindowHeight * 2 / 5 + (writeTop ? 0 : 15));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_fighters[id].Name + " : \n");
            Console.ResetColor();
            Console.WriteLine("\t\tLife : " + _fighters[id].Life + "\n" +
                              "\t\tMana : " + _fighters[id].Mana + "\n" +
                              "\t\tAttack : " + _fighters[id].AttackValue + "\n" +
                              "\t\tDefense : " + _fighters[id].Defense + "\n" +
                              "\t\tInitiative : " + _fighters[id].Initiative + "\n");
        }

        private void DrawFightersInfoRight(int id, bool writeTop = true)
        {
            Console.SetCursorPosition(Console.WindowWidth - _fighters[id].Name.Length - 12,
                Console.WindowHeight * 2 / 5 + (writeTop ? 0 : 15));
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(_fighters[id].Name + " : ");
            Console.ResetColor();

            string info = "\t\tLife : " + _fighters[id].Life + "\n" +
                          "\t\tMana : " + _fighters[id].Mana + "\n" +
                          "\t\tAttack : " + _fighters[id].AttackValue + "\n" +
                          "\t\tDefense : " + _fighters[id].Defense + "\n" +
                          "\t\tInitiative : " + _fighters[id].Initiative + "\n";

            for (int i = 0; i < 5; ++i)
            {
                Console.SetCursorPosition(Console.WindowWidth - 38,
                    Console.WindowHeight * 2 / 5 + i + (writeTop ? 2 : 17));
                Console.Write(info.Split('\n')[i]);
            }
        }

        protected virtual void OnIsPoped()
        {
            IsPoped?.Invoke(this, EventArgs.Empty);
        }
    }
}