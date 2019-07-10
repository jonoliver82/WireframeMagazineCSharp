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
        private const int EXPLOSION_TIME = 50;
        private const int BOMB_TIME = 150;

        private readonly ISpriteService _spriteService;

        public TileFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public Tile CreateGround()
        {
            return new Tile(TileType.Ground, _spriteService.LoadImage("ground.png"));
        }

        public Tile CreateWall()
        {
            return new Tile(TileType.Wall, _spriteService.LoadImage("wall.png"));
        }

        public Tile CreateBrick()
        {
            return new Tile(TileType.Brick, _spriteService.LoadImage("brick.png"));
        }

        public Tile CreateBomb()
        {
            return new Tile(TileType.Bomb, _spriteService.LoadImage("bomb.png"), BOMB_TIME);
        }

        public Tile CreateExplosion()
        {
            return new Tile(TileType.Explosion, _spriteService.LoadImage("explosion.png"), EXPLOSION_TIME);
        }
    }
}
