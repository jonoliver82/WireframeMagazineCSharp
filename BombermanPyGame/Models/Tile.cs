// **********************************************************************************
// Filename					- Tile.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanPyGame.Models
{
    public class Tile
    {
        ////private int _timer = 0;

        public Tile(TileType tileType, Image sprite)
        {
            TileType = tileType;
            Sprite = sprite;
        }

        public TileType TileType { get; set; }

        public Image Sprite { get; set; }

        public int Timer { get; }
    }
}
