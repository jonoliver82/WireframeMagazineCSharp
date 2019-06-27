// **********************************************************************************
// Filename					- EnemyFactory.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using SpawnPyGame.Interfaces;
using SpawnPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpawnPyGame.Factories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly ISpriteService _spriteService;

        public EnemyFactory(ISpriteService spriteService)
        {
            _spriteService = spriteService;
        }

        public LargeEnemy CreateLarge(int x, int y)
        {
            var sprite = _spriteService.LoadImage("large_enemy.png");
            return new LargeEnemy(new Point(x, y), sprite, this);
        }

        public MediumEnemy CreateMedium(int x, int y)
        {
            var sprite = _spriteService.LoadImage("medium_enemy.png");
            return new MediumEnemy(new Point(x, y), sprite, this);
        }

        public SmallEnemy CreateSmall(int x, int y)
        {
            var sprite = _spriteService.LoadImage("small_enemy.png");
            return new SmallEnemy(new Point(x, y), sprite, this);
        }
    }
}
