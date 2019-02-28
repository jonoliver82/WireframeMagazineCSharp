using Core.Interfaces;
using Core.Models;
using Missiles.Interfaces;
using Missiles.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Missiles
{
    public class MissileGame : IMissileGame
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IRandom _random;
        private readonly RenderInformation _renderInformation;

        private DateTime _lastUpdateTime;
        private TimeSpan _timeSpan;

        private List<Missile> _missiles;

        public MissileGame(IDateTimeService dateTimeService, IRandom random, RenderInformation renderInformation)
        {
            _dateTimeService = dateTimeService;
            _random = random;
            _renderInformation = renderInformation;

            _timeSpan = TimeSpan.FromSeconds(0);
            _lastUpdateTime = _dateTimeService.Now;

            _missiles = new List<Missile>();
            NewMissile();
        }

        public void Render(Graphics graphics)
        {
            Update(_dateTimeService.Now - _lastUpdateTime);
            Draw(graphics);

            _lastUpdateTime = _dateTimeService.Now;
        }

        private void Update(TimeSpan timeSinceLastUpdate)
        {
            _timeSpan += timeSinceLastUpdate;

            for (int i = _missiles.Count - 1; i > -1; i--)
            {
                var missile = _missiles[i];
                missile.Update(_dateTimeService.Now - _lastUpdateTime);
                if (missile.IsTrailOffBottomOfScreen())
                {
                    _missiles.Remove(missile);
                }
            }
        }

        private void Draw(Graphics g)
        {
            foreach (var missile in _missiles)
            {
                missile.Draw(g);
            }
        }

        public void NewMissile()
        {
            var missile = new Missile(_random.Next(400, _renderInformation.Width),
                _random.Next(-70, -10),
                TimeSpan.FromSeconds(_random.Next(0, 3)),
                _renderInformation.Height);

            _missiles.Add(missile);
        }
    }
}
