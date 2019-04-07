using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_PGP_2021.src.Fighters;

namespace RPG_PGP_2021.src.GameStates
{
    class FighterSelectionState : AGameState
    {
        private bool _firstFighter = false;
        private string _nameFirstFighter;
        private bool _secondFighter = false;
        private string _nameSecondFighter;
        private string _input;

        public override void DrawHUD()
        {
            base.DrawHUD();
            if (!_firstFighter)
            {
                Console.WriteLine("\n\n\t\tChoose first fighter class\n");
                DisplayClassChoice();
            }
            else
            {
                if (_nameFirstFighter.Length < 2)
                {
                    Console.WriteLine("\n\n\t\tChoose first fighter name\n");
                    if (_nameFirstFighter[0] == 'w' || _nameFirstFighter[0] == 'W')
                        DrawWarrior();
                    else
                        DrawWizard();
                }
                else if (!_secondFighter)
                {
                    Console.WriteLine("\n\n\t\tChoose second fighter class\n");
                    DisplayClassChoice();
                }
                else
                {
                    Console.WriteLine("\n\n\t\tChoose Second fighter name\n");
                    if (_nameSecondFighter[0] == 'w' || _nameSecondFighter[0] == 'W')
                        DrawWarrior();
                    else
                        DrawWizard();
                }
            }
        }

        public override void HandleInput()
        {
            if (!string.IsNullOrEmpty(_nameSecondFighter) && _nameSecondFighter.Length > 1)
                return;

            Console.SetCursorPosition(Console.WindowWidth / 2,
                Console.WindowHeight / 2);

            _input = Console.ReadLine();

            if (string.IsNullOrEmpty(_input))
                return;

            if (!_firstFighter)
            {
                if (_input == "w" || _input == "W" ||
                    _input == "m" || _input == "M")
                {
                    _firstFighter = true;
                    _nameFirstFighter = _input;
                }
            }
            else
            {
                if (_nameFirstFighter.Length < 2)
                    _nameFirstFighter += _input;
                else if (!_secondFighter)
                {
                    if (_input == "w" || _input == "W" ||
                        _input == "m" || _input == "M")
                    {
                        _secondFighter = true;
                        _nameSecondFighter = _input;
                    }
                }
                else
                    _nameSecondFighter += _input;
            }
        }

        public override void Update()
        {
            if (!string.IsNullOrEmpty(_nameSecondFighter) && _nameSecondFighter.Length > 1)
            {
                OnMustPop(true);
                OnAddState(new PlayingState(ChooseClass(_nameFirstFighter),
                    ChooseClass(_nameSecondFighter)));
            }
        }

        private void DisplayClassChoice()
        {
            Console.Write("\t\t\tPress 'w' for a ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Warrior");
            Console.ResetColor();
            Console.Write(" or 'm' for a ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Mage\n");
            Console.ResetColor();
        }

        private void DrawWarrior()
        {
            string warrior =
                "\t                          ,dM\n" +
                "\t                         dMMP\n" +
                "\t                        dMMM'\n" +
                "\t                        \\MM/\n" +
                "\t                        dMMm.\n" +
                "\t                       dMMP'_\\---.\n" +
                "\t                      _| _  p ;88;`.\n" +
                "\t                    ,db; p >  ;8P|  `.\n" +
                "\t                   (``T8b,__,'dP |   |\n" +
                "\t                   |   `Y8b..dP  ;_  |\n" +
                "\t                   |    |`T88P_ /  `\\;\n" +
                "\t                   :_.-~|d8P'`Y/    /\n" +
                "\t                    \\_   TP    ;   7`\n" +
                "\t         ,,__        >   `._  /'  /   `\\_\n" +
                "\t         `._ \"\"\"\"~~~~------|`\\;' ;     ,'\n" +
                "\t            \"\"\"~~~-----~~~'\\__[|;' _.- '  `\n" +
                "\t                    ;--..._     .-'-._     ;\n" +
                "\t                   /      /`~~\"'   ,'`\\_ ,/\n" +
                "\t                  ;_    /'        /    ,/\n" +
                "\t                  | `~-l         ;    /\n" +
                "\t                  `\\    ;       /\\.._|\n" +
                "\t                    \\    \\      \\     \n" +
                "\t                    /`---';      `----'\n" +
                "\t                   (     /\n" +
                "\t                    `---'\n";

            Console.WriteLine(warrior);
        }

        private void DrawWizard()
        {
            string wizard =
                "\t              _,._      \n" +
                "\t  .||,       /_ _\\\\     \n" +
                "\t \\.`',/      |'L'| |    \n" +
                "\t = ,. =      | -,| L    \n" +
                "\t / || \\    ,-'\\\"/,'`.   \n" +
                "\t   ||     ,'   `,,. `.  \n" +
                "\t   ,|____,' , ,;' \\| |  \n" +
                "\t  (3|\\    _/|/'   _| |  \n" +
                "\t   ||/,-''  | >-'' _,\\\\ \n" +
                "\t   ||'      ==\\ ,-'  ,' \n" +
                "\t   ||       |  V \\ ,|  \n" +
                "\t   ||       |    |` |   \n" +
                "\t   ||       |    |   \\  \n" +
                "\t   ||       |    \\    \\ \n" +
                "\t   ||       |     |    \\\n" +
                "\t   ||       |      \\_,-'\n" +
                "\t   ||       |___,,--\")_\\\n" +
                "\t   ||         |_|   ccc/\n" +
                "\t   ||        ccc/       \n" +
                "\t   ||                   \n";

            Console.WriteLine("\n\n" + wizard);
        }


        private AFighter ChooseClass(string str)
        {
            switch (str[0])
            {
                case 'w':
                case 'W':
                    return new Warrior(str.Substring(1));
                case 'm':
                case 'M':
                    return new Wizard(str.Substring(1));
                default:
                    Console.WriteLine("Error Class entry invalid");
                    return null;
            }
        }
    }
}