using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_PGP_2021.src;
using RPG_PGP_2021.src.Fighters;

namespace RPG_PGP_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(1, 1);
            Game game = new Game();

            game.Run();
        }
    }
}
