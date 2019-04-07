using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PGP_2021.src.GameStates
{
    class MenuState : AGameState
    {
        public override void Update()
        {
        }

        public override void HandleInput()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.KeyChar == 'q' || key.KeyChar == 27) // 27 is escape key
                OnMustPop();
            else if (key.KeyChar == 'c' || key.KeyChar == '\r') // '\r' is enter key
                OnAddState(new FighterSelectionState());
        }

        public override void DrawHUD()
        {
            base.DrawHUD();

            DrawStateTitle();
            DrawMenuOptions();
        }

        private void DrawStateTitle()
        {
            string menu = // Ivrit
                " __  __   _____   _   _   _   _ \n" +
                "|  \\/  | | ____| | \\ | | | | | |\n" +
                "| |\\/| | |  _|   |  \\| | | | | |\n" +
                "| |  | | | |___  | |\\  | | |_| |\n" +
                "|_|  |_| |_____| |_| \\_|  \\___/ ";

            Console.ForegroundColor = ConsoleColor.White;

            string lines;
            for (int i = 0; i < 5; ++i)
            {
                lines = menu.Split('\n')[i];
                Console.SetCursorPosition(Math.Abs(Console.WindowWidth - lines.Length) / 2, Console.CursorTop);
                Console.WriteLine(lines);
            }

            Console.WriteLine("\n\n\n\n");
            Console.ResetColor();
        }

        private void DrawMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string play = // Small
                "\t\t  ___  _       _ __   __\n" +
                "\t\t | _ \\| |     /_\\ \\ / /" + "\t\t\t\t\tPress enter or 'c' to start the game\n" +
                "\t\t |  _/| |__  / _ \\ V / \n" +
                "\t\t |_|  |____|/_/ \\_\\|_|  \n\n\n";

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
