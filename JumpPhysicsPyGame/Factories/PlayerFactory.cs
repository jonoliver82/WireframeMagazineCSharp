using JumpPhysicsPyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumpPhysicsPyGame.Models;
using Core.Interfaces;

namespace JumpPhysicsPyGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly ISpriteService _spriteService;

        private const double JUMP_VELOCITY = -0.7;
        private const double YVELOCITY = 0;
        private const double XVELOCITY = 1;
        private const double GRAVITY = 0.008;
        public const int WIDTH = 20;
        public const int HEIGHT = 20;

        private const string FILENAME = "spaceship.png";

        public PlayerFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Player Create(int x, int y)
        {
            var sprite = _spriteService.LoadImage(FILENAME);
            return new Player(x, y, sprite, WIDTH, HEIGHT, JUMP_VELOCITY, XVELOCITY, YVELOCITY, GRAVITY);
        }
    }
}
