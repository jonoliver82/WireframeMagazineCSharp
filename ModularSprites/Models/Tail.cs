﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularSprites.Models
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
