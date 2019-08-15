﻿// **********************************************************************************
// Filename					- WalkRight.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WalkCyclePyGame.Interfaces;

namespace WalkCyclePyGame.States
{
    public class WalkRight : IPlayerState
    {
        private List<Image> _images;

        public WalkRight(Image[] images)
        {
            _images = images.ToList();
        }

        public int FrameCount => _images.Count;

        public Image this[int index] => _images[index];
    }
}
