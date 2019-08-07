// **********************************************************************************
// Filename					- ThrusterMotion.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;
using ThrusterMotionPyGame.Interfaces;
using ThrusterMotionPyGame.Models;

namespace ThrusterMotionPyGame
{
    public class ThrusterMotion : KeyboardPyGame
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 480;

        private readonly ISpriteService _spriteService;

        private Spaceship _spaceship;

        public ThrusterMotion(ITimerFactory timerFactory,
            ISpaceshipFactory spaceshipFactory,
            ISpriteService spriteService)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _spriteService = spriteService;

            _spaceship = spaceshipFactory.Create(WIDTH, HEIGHT);
            _spaceship.Reset();
        }

        public override void Draw(Graphics g)
        {
            var rotated = _spriteService.Rotate(_spaceship.CurrentImage, _spaceship.Angle);
            g.DrawImage(rotated, _spaceship.Position);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // save the spaceship's current angle, as changing the actor's image resets the angle to 0
            var newAngle = _spaceship.Angle;

            // rotate left on left arrow press
            if (KeyboardState[Keys.A] || KeyboardState[Keys.Left])
            {
                newAngle -= _spaceship.TurnSpeed;
            }

            // rorate right on right arrow press
            if (KeyboardState[Keys.D] || KeyboardState[Keys.Right])
            {
                newAngle += _spaceship.TurnSpeed;
            }

            // accelerate forwards on up arrow press
            // and change displayed image
            if (KeyboardState[Keys.W] || KeyboardState[Keys.Up])
            {
                _spaceship.IsThrusting = true;
                _spaceship.Accelerate();
            }
            else
            {
                _spaceship.IsThrusting = false;
            }

            if (KeyboardState[Keys.R])
            {
                _spaceship.Reset();
            }

            // Set the new angle
            _spaceship.UpdateAngle(newAngle);
            _spaceship.CalculatePosition();
        }
    }
}
