﻿// **********************************************************************************
// Filename					- JumpPhysics.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using JumpPhysicsPyGame.Interfaces;
using JumpPhysicsPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JumpPhysicsPyGame
{
    public class JumpPhysics : KeyboardPyGame, IDisposable
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 800;

        private readonly IPlayerFactory _playerFactory;

        private Brush _maroonBrush = new SolidBrush(Color.FromArgb(128, 0, 0));
        private IEnumerable<Rectangle> _platforms;
        private Player _player;

        private bool _disposedValue = false;

        public JumpPhysics(ITimerFactory timerFactory, IPlayerFactory playerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _playerFactory = playerFactory;

            _platforms = new List<Rectangle>()
            {
                { new Rectangle(0, 780, 800, 20) },
                { new Rectangle(200, 700, 100, 100) },
                { new Rectangle(400, 650, 100, 20) },
                { new Rectangle(600, 600, 100, 20) },
            };

            _player = _playerFactory.Create(new Point(50, 450));
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangles(_maroonBrush, _platforms.ToArray());
            g.DrawImage(_player.Sprite, _player.Position);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // Horizontal Movement
            // Calculate new horizontal psition if arrow keys are pressed
            double newX = _player.Position.X;

            if ((KeyboardState[Keys.Left] || KeyboardState[Keys.A]) && _player.Position.X > 0)
            {
                newX -= _player.Velocity.X;
            }

            if ((KeyboardState[Keys.Right] || KeyboardState[Keys.D]) && _player.Position.X < 780)
            {
                newX += _player.Velocity.X;
            }

            // Create rectangle for the new x position
            var newPlayerPositionX = new Rectangle((int)newX, _player.Position.Y, _player.Size.Width, _player.Size.Height);

            // Check whether the new player position collides with any platform
            var xCollision = false;
            foreach (var platform in _platforms)
            {
                xCollision = newPlayerPositionX.IntersectsWith(platform) || xCollision;
            }

            // Only allow the player to move if it doesnt collide with any platforms
            if (!xCollision)
            {
                _player.Position = new Point((int)newX, _player.Position.Y);
            }

            // Vertical Movement
            double newY = _player.Position.Y;

            // Acceleration is rate of change of velocity
            _player.UpdateVelocityForGravity();

            // Velocity is rate of change of position
            newY += _player.Velocity.Y;

            // Create rectangle for the new y position
            var newPlayerPositionY = new Rectangle(_player.Position.X, (int)newY, _player.Size.Width, _player.Size.Height);

            // Check whether the new player position collides with any platform
            var yCollision = false;

            // Also check whether the player is on the ground
            var playerOnGround = false;

            foreach (var platform in _platforms)
            {
                yCollision = newPlayerPositionY.IntersectsWith(platform) || yCollision;

                // Player collided with ground if player's y position is lower than the y position of the platform
                if (newPlayerPositionY.IntersectsWith(platform) && (_player.Position.Y < platform.Y))
                {
                    playerOnGround = true || playerOnGround;

                    // Stick the player to the ground
                    ////_player.Position = new Point(_player.Position.X, _player.Position.Y - _player.Size.Height);
                }
            }

            // Player no longer has vertical velocity if colliding with a platform
            if (yCollision)
            {
                _player.HandleVerticalCollision();
            }
            else
            {
                // Only allow the player to move if it doesn't collide with any platforms
                _player.Position = new Point(_player.Position.X, (int)newY);
            }

            // Pressing space sets a negative vertical velocity only if player is on the ground
            if (KeyboardState[Keys.Space] && playerOnGround)
            {
                _player.UpdateVelocityForJumpOnGround();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _maroonBrush.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
