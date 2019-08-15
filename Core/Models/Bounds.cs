// **********************************************************************************
// Filename					- Bounds.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

namespace Core.Models
{
    public class Bounds
    {
        public Bounds(int top, int left, int bottom, int right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }

        public int Top { get; private set; }

        public int Left { get; private set; }

        public int Bottom { get; private set; }

        public int Right { get; private set; }
    }
}
