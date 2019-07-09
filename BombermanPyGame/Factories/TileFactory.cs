// **********************************************************************************
// Filename					- TileFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Interfaces;
using BombermanPyGame.Models;
using Core.Interfaces;

namespace BombermanPyGame.Factories
{
    public class TileFactory : ITileFactory
    {
        // Constants for tile types
        // TODO: consider enum or class for each
        private const int GROUND = 0;
        private const int WALL = 1;
        private const int BRICK = 2;
        private const int BOMB = 3;
        private const int EXPLOSION = 4;

        private readonly ISpriteService _spriteService;

        public TileFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Tile CreateGround()
        {
            return new Tile(GROUND, _spriteService.LoadImage("ground.png"));
        }

        public Tile CreateWall()
        {
            return new Tile(WALL, _spriteService.LoadImage("wall.png"));
        }
    }
}
