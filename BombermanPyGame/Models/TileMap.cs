// **********************************************************************************
// Filename					- TileMap.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Interfaces;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace BombermanPyGame.Models
{
    public class TileMap
    {
        private static TileType[] _explodableTileTypes = { TileType.Ground, TileType.Brick };
        private static TileType[] _movableTileTypes = { TileType.Ground, TileType.Explosion };

        private Tile[,] _tileMap;
        private ITileFactory _tileFactory;

        public TileMap(int width, int height)
        {
            _tileMap = new Tile[width, height];
        }

        public void Initialise(int width, int height, ITileFactory tileFactory)
        {
            _tileFactory = tileFactory;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x % 2 == 1 && y % 2 == 1)
                    {
                        _tileMap[x, y] = _tileFactory.CreateWall();
                    }
                    else
                    {
                        _tileMap[x, y] = _tileFactory.CreateGround();
                    }
                }
            }
        }

        public Image GetImage(int x, int y)
        {
            return _tileMap[x, y].Sprite;
        }

        public bool CanMoveToPosition(int newX, int newY)
        {
            return _movableTileTypes.Contains(_tileMap[newX, newY].TileType);
        }

        public bool IsTileExplodable(int x, int y)
        {
            return _explodableTileTypes.Contains(_tileMap[x, y].TileType);
        }

        public bool CanCreateExplosion(int x, int y)
        {
            return PointIsWithinMapBounds(x, y) && IsTileExplodable(x, y);
        }

        public void SetBomb(int x, int y)
        {
            _tileMap[x, y] = _tileFactory.CreateBomb();
        }

        public void SetBrick(int x, int y)
        {
            _tileMap[x, y] = _tileFactory.CreateBrick();
        }

        public void SetGround(int x, int y)
        {
            _tileMap[x, y] = _tileFactory.CreateGround();
        }

        public void SetExplosion(int x, int y)
        {
            _tileMap[x, y] = _tileFactory.CreateExplosion();
        }

        public void DecrementTimer(int x, int y)
        {
            if (_tileMap[x, y].Timer > 0)
            {
                _tileMap[x, y].Timer -= 1;
            }
        }

        public bool TimerExpired(int x, int y)
        {
            return _tileMap[x, y].Timer <= 0;
        }

        public bool IsExplosion(int x, int y)
        {
            return _tileMap[x, y].TileType == TileType.Explosion;
        }

        public bool IsBomb(int x, int y)
        {
            return _tileMap[x, y].TileType == TileType.Bomb;
        }

        private bool PointIsWithinMapBounds(int x, int y)
        {
            Debug.Assert(_tileMap.Rank == 2, $"TileMap Array Rank Expected 2 Actual {_tileMap.Rank}");
            return (x >= 0 && x < _tileMap.GetLength(0)) && (y >= 0 && y < _tileMap.GetLength(1));
        }
    }
}
