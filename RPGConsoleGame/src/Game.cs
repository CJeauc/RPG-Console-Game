using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_PGP_2021.src.Fighters;

namespace RPG_PGP_2021.src
{
    class Game
    {
        private Stack<GameStates.AGameState> _states;
        private bool _skip = false;

        public Game()
        {
            PlayWindowAnimation();
            _states = new Stack<GameStates.AGameState>();
            _states.Push(new GameStates.MenuState());
            _states.Peek().MustPop += this.OnMustPop;
            _states.Peek().AddState += this.OnAddState;
        }

        private void PlayWindowAnimation()
        {
            int height = 4;
            while (height < 150)
            {
                Console.SetWindowSize(height, height / 3);
                height += 2;
            }
        }

        public void Run()
        {
            while (_states.Count > 0)
            {
                this.DrawHUD();
                this.Update();
                if (!_skip)
                    this.HandleInput();
                else
                    _skip = false;
            }
        }

        private void DrawHUD()
        {
            if (_states.Any())
                _states.Peek().DrawHUD();
        }

        private void Update()
        {
            if (_states.Any())
                _states.Peek().Update();
        }

        private void HandleInput()
        {
            if (_states.Any())
                _states.Peek().HandleInput();
        }

        public void OnMustPop(object source, bool args)
        {
            _states.Pop();
            _skip = args;
        }

        public void OnAddState(object source, GameStates.AGameState args)
        {
            _states.Push(args);
            _states.Peek().MustPop += this.OnMustPop;
            _states.Peek().AddState += this.OnAddState;
        }
    }
}