// **********************************************************************************
// Filename					- SpaceshipFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System.Drawing;
using ThrusterMotionPyGame.Interfaces;
using ThrusterMotionPyGame.Models;

namespace ThrusterMotionPyGame.Factories
{
    public class SpaceshipFactory : ISpaceshipFactory
    {
        private readonly ISpriteService _spriteService;

        public SpaceshipFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Spaceship Create(int displayWidth, int displayHeight)
        {
            var normalImage = _spriteService.LoadImage("spaceship.png");
            var thrustImage = _spriteService.LoadImage("spaceship-thrust.png");
            var startPosition = new Point((displayWidth / 2) - (normalImage.Width / 2), (displayHeight / 2) - (normalImage.Height / 2));

            var spaceship = new Spaceship(startPosition, normalImage, thrustImage, 0.005, 0.25f);

            return spaceship;
        }
    }
}
