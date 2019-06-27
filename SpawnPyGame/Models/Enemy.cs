// **********************************************************************************
// Filename					- Enemy.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpawnPyGame.Interfaces;
using SpawnPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpawnPyGame.Models
{
    public abstract class Enemy
    {
        private readonly IEnemyFactory _factory;

        private Point _pos;
        private Image _sprite;

        protected Enemy(Point pos, Image sprite, IEnemyFactory factory)
        {
            _pos = pos;
            _sprite = sprite;
            _factory = factory;
        }

        public Point Position => _pos;

        public Image Sprite => _sprite;

        protected IEnemyFactory Factory => _factory;

        public virtual IEnumerable<Enemy> Destroy()
        {
            return new List<Enemy>();
        }
    }
}
