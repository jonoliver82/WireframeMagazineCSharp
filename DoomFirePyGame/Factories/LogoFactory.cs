// **********************************************************************************
// Filename					- LogoFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using DoomFirePyGame.Interfaces;
using DoomFirePyGame.Models;

namespace DoomFirePyGame.Factories
{
    public class LogoFactory : ILogoFactory
    {
        private const int Y_FINAL = 70;
        private const int STEP = -4;
        private const string FILENAME = "doom.png";

        private readonly ISpriteService _spriteService;

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
