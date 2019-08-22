// **********************************************************************************
// Filename					- PowerUp.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace SpriteFollowingPyGame.Models
{
    public class PowerUp
    {
        public PowerUp(Image sprite, Point position)
        {
            Sprite = sprite;
            Position = position;
        }

        public Point Position { get; set; }

        public Image Sprite { get; private set; }
    }
}
