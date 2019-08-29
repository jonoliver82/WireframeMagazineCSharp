// **********************************************************************************
// Filename					- Continue.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ContinuePyGame.Interfaces;
using ContinuePyGame.States;
using Core;
using Core.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContinuePyGame
{
    public class Continue : KeyboardPyGame
    {
        private const int WIDTH = 600;
        private const int HEIGHT = 400;

        private StateManager _stateManager;

        public Continue(ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            var titleScreen = new TitleScreenState();
            var gameScreen = new GameScreenState();
            var continueScreen = new ContinueScreenState();

            titleScreen.AddTransitionRule(gameScreen, () => IsKeyPressed(Keys.Space));
            gameScreen.AddTransitionRule(continueScreen, () => IsKeyPressed(Keys.E));
            continueScreen.AddTransitionRule(titleScreen, IsFrameCounterGreaterThanTen);
            continueScreen.AddTransitionRule(gameScreen, () => IsKeyPressed(Keys.Space));

            _stateManager = new StateManager(titleScreen);
        }

        public override void Draw(Graphics g)
        {
            _stateManager.Draw(g);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _stateManager.Update(timeSinceLastUpdate);
        }

        private bool IsKeyPressed(Keys key)
        {
            return KeyboardState[key];
        }

        private bool IsFrameCounterGreaterThanTen()
        {
            return _stateManager.TimeInStateSeconds >= 10;
        }
    }
}
