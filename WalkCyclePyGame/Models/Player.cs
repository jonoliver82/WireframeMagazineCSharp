// **********************************************************************************
// Filename					- Player.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WalkCyclePyGame.Models
{
    public class Player
    {
        private const int ANIMATION_DELAY = 50;

        private Point _currentPosition;
        private State _state;
        private int _animationTimer = 0;

        // Index within image array for state - walk left and right have multiple frames
        private int _animationIndex = 0;

        private Dictionary<State, Image[]> _stateImages;

        public Player(Point start, Dictionary<State, Image[]> stateImages)
        {
            _currentPosition = start;
            _stateImages = stateImages;

            Stand();
        }

        public int X => _currentPosition.X;

        public void Update()
        {
            if (_stateImages[_state].Length > 0)
            {
                _animationTimer++;
                if (_animationTimer > ANIMATION_DELAY)
                {
                    _animationTimer = 0;
                    _animationIndex++;
                    if (_animationIndex > _stateImages[_state].Length - 1)
                    {
                        _animationIndex = 0;
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(_stateImages[_state][_animationIndex], _currentPosition);
        }

        public void Left()
        {
             _currentPosition = new Point(_currentPosition.X - 1, _currentPosition.Y);
             _state = State.WalkLeft;
        }

        public void Stand()
        {
            _state = State.Stand;
            _animationIndex = 0;
        }

        public void Right()
        {
            _currentPosition = new Point(_currentPosition.X + 1, _currentPosition.Y);
            _state = State.WalkRight;
        }
    }
}
