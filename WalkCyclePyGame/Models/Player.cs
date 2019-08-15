// **********************************************************************************
// Filename					- Player.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WalkCyclePyGame.Events;
using WalkCyclePyGame.Interfaces;

namespace WalkCyclePyGame.Models
{
    public class Player
    {
        private const int ANIMATION_DELAY = 50;

        private Point _currentPosition;
        private Bounds _movementBounds;
        private int _animationTimer = 0;

        // Index within image array for state - walk left and right have multiple frames
        private int _animationIndex = 0;

        public Player(Point start, Bounds movementBounds)
        {
            _currentPosition = start;
            _movementBounds = movementBounds;
        }

        public event EventHandler<StateTransitionEventArgs> ChangeState;

        public IPlayerState WalkingState { get; set; }

        public void Update()
        {
            if (WalkingState.FrameCount > 0)
            {
                _animationTimer++;
                if (_animationTimer > ANIMATION_DELAY)
                {
                    _animationTimer = 0;
                    _animationIndex++;
                    if (_animationIndex > WalkingState.FrameCount - 1)
                    {
                        _animationIndex = 0;
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(WalkingState[_animationIndex], _currentPosition);
        }

        public void TryMoveLeft()
        {
            if (_currentPosition.X > _movementBounds.Left)
            {
                _currentPosition = new Point(_currentPosition.X - 1, _currentPosition.Y);
                ChangeState?.Invoke(this, new StateTransitionEventArgs(State.WalkLeft));
            }
        }

        public void Stand()
        {
            _animationIndex = 0;
            ChangeState?.Invoke(this, new StateTransitionEventArgs(State.Stand));
        }

        public void TryMoveRight()
        {
            if (_currentPosition.X < _movementBounds.Right)
            {
                _currentPosition = new Point(_currentPosition.X + 1, _currentPosition.Y);
                ChangeState?.Invoke(this, new StateTransitionEventArgs(State.WalkRight));
            }
        }
    }
}
