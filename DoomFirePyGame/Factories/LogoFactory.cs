using DoomFirePyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoomFirePyGame.Models;
using Core.Interfaces;

namespace DoomFirePyGame.Factories
{
    public class LogoFactory : ILogoFactory
    {
        private readonly ISpriteService _spriteService;

        private const int Y_FINAL = 70;
        private const int STEP = -4;
        private const string FILENAME = "doom.png";

        public LogoFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Logo Create(int x, int y)
        {
            var sprite = _spriteService.LoadImage(FILENAME);
            return new Logo(x, y, sprite, Y_FINAL, STEP);
        }
    }
}
