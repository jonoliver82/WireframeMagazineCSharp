// **********************************************************************************
// Filename					- PlayerFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Interfaces;
using BombermanPyGame.Models;
using Core.Interfaces;

namespace BombermanPyGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly ISpriteService _spriteService;

        public PlayerFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Player Create(int x, int y)
        {
            return new Player(_spriteService.LoadImage("player.png"), x, y);
        }
    }
}
