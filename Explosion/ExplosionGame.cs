using Core;
using Core.Interfaces;
using Core.Models;
using Explosion.Interfaces;
using System;
using System.Drawing;

namespace Explosion
{
    public class ExplosionGame : IExplosionGame
    {
        private readonly RenderInformation _renderInfo;        
        private readonly IRandom _random;
        private readonly IDateTimeService _dateTimeService;
        private readonly IExplosionService _explosionService;

        private DateTime _lastUpdateTime;

        public ExplosionGame(IRandom random, 
            IDateTimeService dateTimeService,
            RenderInformation renderInformation,
            IExplosionService explosionService)
        {
            _random = random;
            _dateTimeService = dateTimeService;
            _renderInfo = renderInformation;            
            _explosionService = explosionService;

            _lastUpdateTime = _dateTimeService.Now;
        }

        public void Render(Graphics g)
        {            
            _explosionService.UpdateParticles(_dateTimeService.Now - _lastUpdateTime);

            DrawParticles(g);

            _lastUpdateTime = _dateTimeService.Now;
        }

        /// <summary>
        /// This function redraws the screen by plotting each particle in the array
        /// </summary>
        /// <param name="g"></param>
        private void DrawParticles(Graphics g)
        {
            foreach(var particle in _explosionService.Particles)
            {
                g.FillRectangle(particle.Brush, (int)Math.Round(particle.X), (int)Math.Round(particle.Y), 1, 1);
            }
        }

        /// <summary>
        /// This function creates an explosion at a random location on the screen
        /// </summary>
        public void ExplodeRandom()
        {
            // select a random position on the screen
            var x = _random.Next(_renderInfo.Width);
            var y = _random.Next(_renderInfo.Height);

            //call the explosion function for that position
            _explosionService.Add(x, y);
        }
    }
}
