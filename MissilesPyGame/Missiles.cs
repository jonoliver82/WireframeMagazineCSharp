// **********************************************************************************
// Filename					- Missiles.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using MissilesPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MissilesPyGame
{
    public class Missiles : PyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 400;

        private readonly IRandom _random;

        private List<Missile> _missiles;

        public Missiles(ITimerFactory timerFactory, IRandom random)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _random = random;

            _missiles = new List<Missile>();
            NewMissile();

            ScheduleClockInterval(NewMissile, 5000);
        }

        public override void Draw(Graphics g)
        {
            foreach (var missile in _missiles)
            {
                missile.Draw(g);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            for (int i = _missiles.Count - 1; i > -1; i--)
            {
                var missile = _missiles[i];
                missile.Update(timeSinceLastUpdate);
                if (missile.IsTrailOffBottomOfScreen())
                {
                    _missiles.Remove(missile);
                }
            }
        }

        public void NewMissile()
        {
            var missile = new Missile(_random.Next(400, WIDTH),
                _random.Next(-70, -10),
                TimeSpan.FromSeconds(_random.Next(0, 3)),
                HEIGHT);

            _missiles.Add(missile);
        }
    }
}
