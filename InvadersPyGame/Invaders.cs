// **********************************************************************************
// Filename					- Invaders.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using InvadersPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace InvadersPyGame
{
    public class Invaders : PyGame
    {
        private const int WIDTH = 1200;
        private const int HEIGHT = 700;
        private const int SHOT_SPEED = 20;

        private readonly IGraphicsService _graphicsService;
        private readonly ISpriteService _spriteService;
        private readonly IRandom _random;

        private bool _firstFrame = true;
        private List<Shot> _shots = new List<Shot>();
        private List<Shot> _toDelete = new List<Shot>();

        public Invaders(IGraphicsService graphicsService,
            ISpriteService spriteService,
            ITimerFactory timerFactory,
            IRandom random)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _graphicsService = graphicsService;
            _spriteService = spriteService;
            _random = random;

            ScheduleClockInterval(CreateRandomShot, 500);
        }

        public override void Draw(Graphics g)
        {
            if (_firstFrame)
            {
                g.Clear(Color.Black);
                var shield = _spriteService.LoadImage("shield.png");
                for (int x = 50; x < WIDTH; x += 300)
                {
                    g.DrawImage(shield, new Point(x, 500));
                }

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

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
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
                            Sprite = _spriteService.LoadImage("explode_black.png"),
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
                        Sprite = _spriteService.LoadImage("shot_black.png"),
                    });

                    // Move down the screen
                    shot.Position = new Point(shot.Position.X, shot.Position.Y + SHOT_SPEED);

                    // Do collision detection based on the centre of the sprite
                    var halfWidth = shot.Sprite.Width / 2;
                    var halfHeight = shot.Sprite.Height / 2;

                    if (shot.Position.Y + halfHeight >= HEIGHT)
                    {
                        _shots.RemoveAt(i);
                    }
                    else
                    {
                        // Hit something? If so change to exploding sprite
                        var collideCheckPosition = new Point(shot.Position.X + halfWidth, shot.Position.Y + halfHeight);
                        var testColor = _graphicsService.GetScreenColorAtPosition(g, collideCheckPosition);
                        if (!_graphicsService.ColorRgbEquals(testColor, Color.Black))
                        {
                            shot.Sprite = _spriteService.LoadImage("explode.png");
                            shot.Exploding = true;
                            shot.Timer = 5;
                        }
                    }
                }
            }
        }

        private void CreateRandomShot()
        {
            _shots.Add(new Shot
            {
                Sprite = _spriteService.LoadImage("shot.png"),
                Position = new Point(_random.Next(WIDTH), 0),
                Exploding = false,
            });
        }
    }
}
