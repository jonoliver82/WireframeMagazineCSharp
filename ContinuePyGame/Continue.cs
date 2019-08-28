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

            titleScreen.AddTransitionRule(continueScreen, () => KeyboardState[Keys.Space]);
            gameScreen.AddTransitionRule(continueScreen, () => KeyboardState[Keys.E]);
            continueScreen.AddTransitionRule(continueScreen, () => _stateManager.Frame >= 10);
            continueScreen.AddTransitionRule(continueScreen, () => KeyboardState[Keys.Space]);

            _stateManager = new StateManager(titleScreen);
        }

        public override void Draw(Graphics g)
        {
            _stateManager.Draw(g);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _stateManager.Update();
        }
    }
}
