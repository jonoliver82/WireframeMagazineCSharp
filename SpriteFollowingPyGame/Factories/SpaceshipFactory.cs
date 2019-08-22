// **********************************************************************************
// Filename					- SpaceshipFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using SpriteFollowingPyGame.Interfaces;
using SpriteFollowingPyGame.Models;
using System;
using System.Drawing;

namespace SpriteFollowingPyGame.Factories
{
    public class SpaceshipFactory : ISpaceshipFactory
    {
        private readonly ISpriteService _spriteService;

        public SpaceshipFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Spaceship Create(Point startPosition)
        {
            var normalImage = _spriteService.LoadImage("spaceship.png");
            return new Spaceship(startPosition, normalImage, 4);
        }
    }
}
