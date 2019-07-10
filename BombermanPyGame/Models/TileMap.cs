// **********************************************************************************
// Filename					- TileMap.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;
using BombermanPyGame.Interfaces;
using System.Linq;

namespace BombermanPyGame.Models
{
    public class TileMap
    {
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

        public void SetBrick(int x, int y)
        {
            _tileMap[x, y] = _tileFactory.CreateBrick();
        }

        public Image GetImage(int x, int y)
        {
            return _tileMap[x, y].Sprite;
        }

        public bool CanMoveToPosition(int newX, int newY)
        {
            var movableTileTypes = new TileType[]
            {
                TileType.Ground,
                TileType.Explosion,
            };

            return movableTileTypes.Contains(_tileMap[newX, newY].TileType);
        }

        public void SetBomb(int x, int y)
        {
            _tileMap[x, y] = _tileFactory.CreateBomb();
            _tileMap[x, y].BombTimer = 150;
        }
    }
}
