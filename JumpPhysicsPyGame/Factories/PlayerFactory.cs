// **********************************************************************************
// Filename					- PlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using Core.Models;
using JumpPhysicsPyGame.Interfaces;
using JumpPhysicsPyGame.Models;
using System.Drawing;

namespace JumpPhysicsPyGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private const double JUMP_VELOCITY = -0.7;
        private const double YVELOCITY = 0;
        private const double XVELOCITY = 1;
        private const double GRAVITY = 0.008;
        private const int WIDTH = 20;
        private const int HEIGHT = 20;

        private const string FILENAME = "spaceship.png";

        private readonly ISpriteService _spriteService;

        public PlayerFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Player Create(Point position)
        {
            var sprite = _spriteService.LoadImage(FILENAME);
            return new Player(position, sprite, new Size(WIDTH, HEIGHT), JUMP_VELOCITY, new Velocity(XVELOCITY, YVELOCITY), GRAVITY);
        }
    }
}
