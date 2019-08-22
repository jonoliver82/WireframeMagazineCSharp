// **********************************************************************************
// Filename					- SpriteFollowing.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using SpriteFollowingPyGame.Interfaces;
using SpriteFollowingPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpriteFollowingPyGame
{
    public class SpriteFollowing : KeyboardPyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 800;
        private const int POWERUP_COUNT = 3;

        private Spaceship _spaceship;
        private List<PowerUp> _powerups;

        public SpriteFollowing(ISpaceshipFactory spaceshipFactory,
            IPowerUpFactory powerupFactory,
            ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _spaceship = spaceshipFactory.Create(new Point(400, 400));
            _powerups = powerupFactory.CreatePowerUps(POWERUP_COUNT);

            _spaceship.PopulateDefaultPreviousPositions();
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_spaceship.Sprite, _spaceship.Position);
            foreach (var powerup in _powerups)
            {
                g.DrawImage(powerup.Sprite, powerup.Position);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // Store spaceship previous position
            var previousPosition = _spaceship.Position;

            // Use arrow keys to move the spaceship
            if (KeyboardState[Keys.Left] || KeyboardState[Keys.A])
            {
                _spaceship.MoveLeft();
            }

            if (KeyboardState[Keys.Right] || KeyboardState[Keys.D])
            {
                _spaceship.MoveRight();
            }

            if (KeyboardState[Keys.Up] || KeyboardState[Keys.W])
            {
                _spaceship.MoveUp();
            }

            if (KeyboardState[Keys.Down] || KeyboardState[Keys.S])
            {
                _spaceship.MoveDown();
            }

            // Add new position to list if the spaceship has moved
            if (previousPosition != _spaceship.Position)
            {
                _spaceship.StorePosition();
            }

            // Set the new position of each powerup
            // Python uses enumerate
            // for counter,value in enumerate(some_list):
            foreach (var it in _powerups.Select((value, index) => new { Value = value, Index = index }))
            {
                var newPosition = _spaceship.PreviousPosition((it.Index + 1) * 20);
                it.Value.Position = newPosition;
            }
        }
    }
}
