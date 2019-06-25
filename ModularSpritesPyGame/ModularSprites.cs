// **********************************************************************************
// Filename					- ModularSprites.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using ModularSpritesPyGame.Interfaces;
using ModularSpritesPyGame.Models;
using ModularSpritesPyGame.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ModularSpritesPyGame
{
    public class ModularSprites : PyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 800;

        private readonly SpriteOptions _options;
        private List<Tail> _tails;
        private TimeSpan _timeSpan;

        public ModularSprites(ITimerFactory timerFactory, ITailFactory tailFactory, SpriteOptions options)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _options = options;

            _timeSpan = TimeSpan.FromSeconds(0);

            // Fill with 10 tail piece and 1 hook at the end
            _tails = Enumerable.Range(0, 10).Select(x => tailFactory.CreateTailPiece()).ToList<Tail>();
            _tails.Add(tailFactory.CreateTailHook());
        }

        public override void Draw(Graphics g)
        {
            // Python [::2] - step 2
            // Enumerate the event tail pieces
            for (int i = 0; i < _tails.Count; i += 2)
            {
                g.DrawImage(_tails[i].Sprite, _tails[i].Position);
            }

            // Python [1::2] - start 1 step 2
            // Enumerate the odd tail pieces
            for (int i = 1; i < _tails.Count; i += 2)
            {
                g.DrawImage(_tails[i].Sprite, _tails[i].Position);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _timeSpan += timeSinceLastUpdate;

            // Start at the bottom right
            var x = WIDTH - (_options.SegmentSize / 2);
            var y = HEIGHT - (_options.SegmentSize / 2);

            // Note python's enumerate provides counter,value
            // C#'s foreach only provides the value
            int counter = 0;
            foreach (var item in _tails)
            {
                item.Position = new Point(x, y);

                // Calculate an angle to the next piece which wobbles sinusoidally
                var angle = _options.Angle + (_options.WobbleAmount * Math.Sin((counter * _options.PhaseStep) + (_timeSpan.TotalSeconds * _options.Speed)));

                // Get the positon of the next piece using trigonometry
                x += (int)(_options.SegmentSize * Math.Cos(angle));
                y -= (int)(_options.SegmentSize * Math.Sin(angle));

                // Manually increment the counter that python's enumerate would use
                counter++;
            }
        }
    }
}
