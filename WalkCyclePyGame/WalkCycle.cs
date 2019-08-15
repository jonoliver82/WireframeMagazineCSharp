// **********************************************************************************
// Filename					- WalkCycle.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using Core.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using WalkCyclePyGame.Events;
using WalkCyclePyGame.Interfaces;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame
{
    public class WalkCycle : KeyboardPyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 300;
        private const int LEFT_BOUND = 10;
        private const int RIGHT_BOUND = WIDTH - 80;

        private readonly IStateFactory _stateFactory;
        private readonly IStateChangeRecorder _stateChangeRecorder;

        private Player _player;

        public WalkCycle(IPlayerFactory playerFactory,
            IStateFactory stateFactory,
            ITimerFactory timerFactory,
            IStateChangeRecorder stateChangeRecorder)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _player = playerFactory.Create(new Point(375, 100), new Bounds(0, LEFT_BOUND, HEIGHT, RIGHT_BOUND));
            _stateFactory = stateFactory;
            _stateChangeRecorder = stateChangeRecorder;

            _stateChangeRecorder.Start();

            // Subscribe to state change request events from the player
            // This decouples the player object from the mechanism to change its own state - the player object does not
            // need to have a reference to the state factory. In addition, other objects may also subscribe to the change of state
            _player.ChangeState += _player_ChangeState;
        }

        public override void Draw(Graphics g)
        {
            _player.Draw(g);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            if (KeyboardState[Keys.Left] || KeyboardState[Keys.A])
            {
                _player.TryMoveLeft();
            }
            else if (KeyboardState[Keys.Right] || KeyboardState[Keys.D])
            {
                _player.TryMoveRight();
            }
            else if (KeyboardState[Keys.S])
            {
                _stateChangeRecorder.LogAndReset();
            }
            else
            {
                _player.Stand();
            }

            _player.Update();
        }

        private void _player_ChangeState(object sender, StateTransitionEventArgs e)
        {
            // Only change state if necessary
            if (_player.WalkingState.State != e.DesiredState)
            {
                _player.WalkingState = _stateFactory.Create(e.DesiredState);
                _stateChangeRecorder.RecordChange(e.DesiredState);
            }
        }
    }
}
