// **********************************************************************************
// Filename					- PowerUpFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using SpriteFollowingPyGame.Interfaces;
using SpriteFollowingPyGame.Models;
using System.Collections.Generic;
using System.Drawing;

namespace SpriteFollowingPyGame.Factories
{
    public class PowerUpFactory : IPowerUpFactory
    {
        private readonly ISpriteService _spriteService;

        public PowerUpFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public List<PowerUp> CreatePowerUps(int quantity)
        {
            var image = _spriteService.LoadImage("powerup.png");
            var result = new List<PowerUp>(quantity);

            for (int i = 0; i < quantity; i++)
            {
                result.Add(new PowerUp(image, default(Point)));
            }

            return result;
        }
    }
}
