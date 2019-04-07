using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.GameStates
{
    class GameOverState : AGameState
    {
        private string _winnerName;
        private string _looserName;

        public GameOverState(string winnerName, string losserName)
        {
            _winnerName = winnerName;
            _looserName = losserName;
        }

        public override void DrawHUD()
        {
            base.DrawHUD();
            DrawStateTitle();
            string message = "The fight is over, " +
                             ((_winnerName != null)
                                 ? (_winnerName + " overpowered " + _looserName +
                                    " in a great and violent fight to survive")
                                 : ("Its a draw, there is no winner")) + "\n\n";

            Console.SetCursorPosition(Math.Abs(Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);

            DrawMenuOptions();
        }

        public override void HandleInput()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.KeyChar == 'q' || key.KeyChar == 27) // 27 is escape key
                OnMustPop();
            else if (key.KeyChar == 'r' || key.KeyChar == '\r') // '\r' is enter key
            {
                OnMustPop();
                OnAddState(new FighterSelectionState());
            }
        }

        public override void Update()
        {
        }

        private void DrawStateTitle()
        {
            string gameOver = // Ivrit
                "   ____     _     __  __  _____    ___ __     __ _____  ____  \n" +
                "  / ___|   / \\   |  \\/  || ____|  / _ \\\\ \\   / /| ____||  _ \\ \n" +
                " | |  _   / _ \\  | |\\/| ||  _|   | | | |\\ \\ / / |  _|  | |_) |\n" +
                " | |_| | / ___ \\ | |  | || |___  | |_| | \\ V /  | |___ |  _ < \n" +
                "  \\____|/_/   \\_\\|_|  |_||_____|  \\___/   \\_/   |_____||_| \\_\\\n";

            Console.ForegroundColor = ConsoleColor.DarkRed;

            string lines;
            for (int i = 0; i < 5; ++i)
            {
                lines = gameOver.Split('\n')[i];
                Console.SetCursorPosition(Math.Abs(Console.WindowWidth - lines.Length) / 2, Console.CursorTop);
                Console.WriteLine(lines);
            }

            Console.WriteLine("\n");
            Console.ResetColor();
        }

        private void DrawMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string play = // Small
                "\t\t  ___  ___  ___  _____  _    ___  _____ \n" +
                "\t\t | _ \\| __|/ __||_   _|/_\\  | _ \\|_   _|" + "\t\tPress enter or 'c' to restart the game\n" +
                "\t\t |   /| _| \\__ \\  | | / _ \\ |   /  | |  \n" +
                "\t\t |_|_\\|___||___/  |_|/_/ \\_\\|_|_\\  |_|  \n\n\n";

            Console.WriteLine(play);
            Console.ResetColor();

            string quit = // Small
                "\t\t   ___   _   _  ___  _____ \n" +
                "\t\t  / _ \\ | | | ||_ _||_   _|" + "\t\t\t\tPress escape or 'q' to quit\n" +
                "\t\t | (_) || |_| | | |   | |  \n" +
                "\t\t  \\__\\_\\ \\___/ |___|  |_|  \n";

            Console.WriteLine(quit);
        }
    }
}