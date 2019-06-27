// **********************************************************************************
// Filename					- MediumEnemy.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpawnPyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpawnPyGame.Models
{
    public class MediumEnemy : Enemy
    {
        public MediumEnemy(Point pos, Image sprite, IEnemyFactory factory)
            : base(pos, sprite, factory)
        {
        }

        public override IEnumerable<Enemy> Destroy()
        {
            // spawn 2 small-sized enemies when destroying
            return new List<Enemy>
            {
                Factory.CreateSmall(Position.X - 20, Position.Y - 20),
                Factory.CreateSmall(Position.X + 20, Position.Y + 20),
            };
        }
    }
}
