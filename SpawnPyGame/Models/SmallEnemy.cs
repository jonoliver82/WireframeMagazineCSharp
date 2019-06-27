// **********************************************************************************
// Filename					- SmallEnemy.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using SpawnPyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpawnPyGame.Models
{
    public class SmallEnemy : Enemy
    {
        public SmallEnemy(Point pos, Image sprite, IEnemyFactory factory)
            : base(pos, sprite, factory)
        {
        }
    }
}
