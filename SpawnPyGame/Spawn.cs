// **********************************************************************************
// Filename					- Spawn.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using SpawnPyGame.Interfaces;
using SpawnPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpawnPyGame
{
    public class Spawn : KeyboardPyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 800;

        private List<Enemy> _enemies;

        public Spawn(ITimerFactory timerFactory, IEnemyFactory enemeyFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _enemies = new List<Enemy>();

            _enemies.Add(enemeyFactory.CreateLarge(300, 150));
            _enemies.Add(enemeyFactory.CreateLarge(150, 300));
        }

        public override void Draw(Graphics g)
        {
            foreach (var enemy in _enemies)
            {
                g.DrawImage(enemy.Sprite, enemy.Position);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // No action required
        }

        public override void KeyDown(Keys keyCode)
        {
            if (_enemies.Any())
            {
                var result = _enemies.ElementAt(0).Destroy();
                if (result.Any())
                {
                    _enemies.AddRange(result);
                }

                _enemies.RemoveAt(0);
            }
        }
    }
}
