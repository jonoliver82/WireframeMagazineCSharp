using Core.Interfaces;
using Core.Interop;
using Core.Models;
using Invaders.Interfaces;
using Invaders.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Invaders
{
    public class InvadersGame : IInvadersGame
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IRandom _random;
        private readonly RenderInformation _renderInformation;
        
        private DateTime _lastUpdateTime;

        private const int SHOT_SPEED = 20;

        private List<Shot> _shots;
        private List<Shot> _toDelete;
        private bool _firstFrame;

        public InvadersGame(IDateTimeService dateTimeService, IRandom random, RenderInformation renderInformation)
        {
            _dateTimeService = dateTimeService;
            _random = random;
            _renderInformation = renderInformation;

            _lastUpdateTime = _dateTimeService.Now;

            _shots = new List<Shot>();
            _toDelete = new List<Shot>();
            _firstFrame = true;
        }

        public void Render(Graphics graphics)
        {
            Update(_dateTimeService.Now - _lastUpdateTime, graphics);
            Draw(graphics);

            _lastUpdateTime = _dateTimeService.Now;
        }

        private void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // Step backwards through the shots list. This avoids errors that occur
            // when deleting items from the list during the for loop.
            for (int i = _shots.Count - 1; i >= 0; i--)
            {
                var shot = _shots.ElementAt(i);
                if (shot.Exploding)
                {
                    shot.Timer -= 1;
                    if (shot.Timer <= 0)
                    {
                        _toDelete.Add(new Shot
                        {
                            Position = shot.Position,
                            Sprite = Bitmap.FromFile("explode_black.png"),
                        });
                        _shots.RemoveAt(i);
                    }
                }
                else
                {
                    // Before moving shot, add the current position to the to_delete list
                    _toDelete.Add(new Shot
                    {
                        Position = shot.Position,
                        Sprite = Bitmap.FromFile("shot_black.png"),
                    });

                    // Move down the screen
                    shot.Position = new Point(shot.Position.X, shot.Position.Y + SHOT_SPEED);

                    // Do collision detection based on the centre of the sprite
                    var halfWidth = shot.Sprite.Width / 2;
                    var halfHeight = shot.Sprite.Height / 2;

                    if (shot.Position.Y + halfHeight >= _renderInformation.Height)
                    {
                        _shots.RemoveAt(i);
                    }
                    else
                    {
                        // Hit something? If so change to exploding sprite
                        var collideCheckPosition = new Point(shot.Position.X + halfWidth, shot.Position.Y + halfHeight);
                        var testColor = GetScreenColorAtPosition(g, collideCheckPosition);
                        if (!ColorRgbEquals(testColor, Color.Black))
                        {
                            shot.Sprite = Bitmap.FromFile("explode.png");
                            shot.Exploding = true;
                            shot.Timer = 5;
                        }
                    }
                }
            }
        }

        private Color GetScreenColorAtPosition(Graphics g, Point position)
        {
            IntPtr hdc = IntPtr.Zero;
            try
            {
                hdc = g.GetHdc();
                var color = GDI.GetPixel(hdc, position.X, position.Y);
                return Color.FromArgb((int)color);
            }
            finally
            {
                g.ReleaseHdc(hdc);
            }
        }

        /// <summary>
        /// Compares Colors without considering the value of the Alpha channel
        /// </summary>
        private bool ColorRgbEquals(Color first, Color second)
        {
            return first.R == second.R && first.G == second.G && first.B == second.B;
        }

        private void Draw(Graphics g)
        {
            if(_firstFrame)
            {
                g.Clear(Color.Black);
                AddShields(g);
                _firstFrame = false;
            }

            foreach (var item in _toDelete)
            {
                g.DrawImage(item.Sprite, item.Position);
            }
            _toDelete.Clear();

            foreach (var shot in _shots)
            {
                g.DrawImage(shot.Sprite, shot.Position);
            }
        }

        private void AddShields(Graphics g)
        {
            var shield = Bitmap.FromFile("shield.png");
            for (int x = 50; x < _renderInformation.Width; x+= 300)
            {
                g.DrawImage(shield, new Point(x, 500));
            }
        }

        public void CreateRandomShot()
        {
            _shots.Add(new Shot
            {
                Sprite = Bitmap.FromFile("shot.png"),
                Position = new Point(_random.Next(_renderInformation.Width), 0),
                Exploding = false,
            });            
        }
    }
}
