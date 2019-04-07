using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RPG_PGP_2021.src.GameStates
{
    abstract class AGameState
    {
        public event EventHandler<bool> MustPop;
        public event EventHandler<AGameState> AddState;

        protected virtual void OnMustPop(bool arg = false)
        {
            MustPop?.Invoke(this, arg);
        }

        protected virtual void OnAddState(AGameState newState)
        {
            AddState?.Invoke(this, newState);
        }

        public abstract void Update();
        public abstract void HandleInput();

        public virtual void DrawHUD()
        {
            Console.Clear();
            DrawGameTitle();
        }

        private void DrawGameTitle()
        {
            string title = "\n" +
                           "████████╗██╗   ██╗██████╗ ██████╗  ██████╗     ███████╗██╗ ██████╗ ██╗  ██╗████████╗\n" +
                           "╚══██╔══╝██║   ██║██╔══██╗██╔══██╗██╔═══██╗    ██╔════╝██║██╔════╝ ██║  ██║╚══██╔══╝\n" +
                           "   ██║   ██║   ██║██████╔╝██████╔╝██║   ██║    █████╗  ██║██║  ███╗███████║   ██║   \n" +
                           "   ██║   ██║   ██║██╔══██╗██╔══██╗██║   ██║    ██╔══╝  ██║██║   ██║██╔══██║   ██║   \n" +
                           "   ██║   ╚██████╔╝██║  ██║██████╔╝╚██████╔╝    ██║     ██║╚██████╔╝██║  ██║   ██║   \n" +
                           "   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═════╝  ╚═════╝     ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \n" +
                           " █████╗ ██████╗ ███████╗███╗   ██╗ █████╗ \n" +
                           "██╔══██╗██╔══██╗██╔════╝████╗  ██║██╔══██╗\n" +
                           "███████║██████╔╝█████╗  ██╔██╗ ██║███████║\n" +
                           "██╔══██║██╔══██╗██╔══╝  ██║╚██╗██║██╔══██║\n" +
                           "██║  ██║██║  ██║███████╗██║ ╚████║██║  ██║\n" +
                           "╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝\n";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string lines;
            for (int i = 0; i <= 12; ++i)
            {
                lines = title.Split('\n')[i];
                Console.SetCursorPosition(Math.Abs(Console.WindowWidth - lines.Length) / 2, Console.CursorTop);
                Console.WriteLine(lines);
            }

            Console.ResetColor();
            Console.WriteLine("\n");
        }
    }
}