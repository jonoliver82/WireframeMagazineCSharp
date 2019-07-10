// **********************************************************************************
// Filename					- Player.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace BombermanPyGame.Models
{
    public class Player
    {
        public Player(Image sprite, int x, int y)
        {
            Sprite = sprite;
            X = x;
            Y = y;
        }

        public Image Sprite { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
