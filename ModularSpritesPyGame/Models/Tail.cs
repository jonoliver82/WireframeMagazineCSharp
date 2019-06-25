// **********************************************************************************
// Filename					- Tail.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace ModularSpritesPyGame.Models
{
    public abstract class Tail
    {
        private Image _sprite;

        public Tail(Image sprite)
        {
            _sprite = sprite;
        }

        public Point Position { get; set; }

        public Image Sprite => _sprite;
    }
}
