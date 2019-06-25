// **********************************************************************************
// Filename					- Shot.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace InvadersPyGame.Models
{
    public class Shot
    {
        public Image Sprite { get; set; }

        public Point Position { get; set; }

        public bool Exploding { get; set; }

        public int Timer { get; set; }
    }
}
