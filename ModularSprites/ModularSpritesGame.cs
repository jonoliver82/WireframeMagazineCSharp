using ModularSprites.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Core.Interfaces;
using Core;
using ModularSprites.Models;
using ModularSprites.Options;
using Core.Models;

namespace ModularSprites
{
    public class ModularSpritesGame : IModularSpritesGame
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly RenderInformation _renderInformation;
        private readonly SpriteOptions _options; 
        private DateTime _lastUpdateTime;
        private TimeSpan _timeSpan;

        private List<Tail> _tails;

        public ModularSpritesGame(IDateTimeService dateTimeService, 
            RenderInformation renderInformation,
            SpriteOptions options)
        {
            _dateTimeService = dateTimeService;
            _renderInformation = renderInformation;
            _options = options;

            _timeSpan = TimeSpan.FromSeconds(0);
            _lastUpdateTime = _dateTimeService.Now;

            // Fill with 10 tail piece and 1 hook at the end
            _tails = Enumerable.Range(0, 10).Select(x => new TailPiece()).ToList<Tail>();
            _tails.Add(new TailHook());
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

            // Start at the bottom right
            var x = _renderInformation.Width - _options.SegmentSize / 2;
            var y = _renderInformation.Height - _options.SegmentSize / 2;

            // Note python's enumerate provides counter,value
            // C#'s foreach only provides the value
            int counter = 0;
            foreach (var item in _tails)
            {
                item.Position = new Point(x, y);

                // Calculate an angle to the next piece which wobbles sinusoidally
                var angle = _options.Angle + _options.WobbleAmount * Math.Sin(counter * _options.PhaseStep + _timeSpan.TotalSeconds * _options.Speed);

                // Get the positon of the next piece using trigonometry
                x += (int)(_options.SegmentSize * Math.Cos(angle));
                y -= (int)(_options.SegmentSize * Math.Sin(angle));

                // Manually increment the counter that python's enumerate would use
                counter++;
            }
        }

        private void Draw(Graphics g)
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
    }
}
