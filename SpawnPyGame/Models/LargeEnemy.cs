// **********************************************************************************
// Filename					- LargeEnemy.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpawnPyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpawnPyGame.Models
{
    public class LargeEnemy : Enemy
    {
        public LargeEnemy(Point pos, Image sprite, IEnemyFactory factory)
            : base(pos, sprite, factory)
        {
        }

        public override IEnumerable<Enemy> Destroy()
        {
            // spawn 2 medium-sized enemies when destroying
            return new List<Enemy>
            {
                Factory.CreateMedium(Position.X - 40, Position.Y - 40),
                Factory.CreateMedium(Position.X + 40, Position.Y + 40),
            };
        }
    }
}
