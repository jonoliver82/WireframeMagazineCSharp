// **********************************************************************************
// Filename					- Lemmings.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using LemmingsPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LemmingsPyGame
{
    public class Lemmings : PyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 800;
        private const int MAX_LEMMINGS = 10;
        private const int SPAWN_INTERVAL = 10;

        private Level _level;
        private List<Lemming> _lemmings;
        private Point _startPosition;
        private double _timer;
        private Image _lemmingSprite;

        public Lemmings(ISpriteService spriteService, ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _level = new Level((Bitmap)spriteService.LoadImage("level.png"));
            _lemmingSprite = spriteService.LoadImage("lemming.png");

            _lemmings = new List<Lemming>();
            _startPosition = new Point(100, 100);
            _timer = 0;
        }

        public override void Draw(Graphics g)
        {
            // Draw the level
            _level.Draw(g);

            // Draw the lemmings
            foreach (var lemming in _lemmings)
            {
                lemming.Draw(g);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // Increment the timer and create a new lemming if the interval has passed
            _timer += 0.1;
            if (_timer > SPAWN_INTERVAL && _lemmings.Count < MAX_LEMMINGS)
            {
                _timer = 0;
                _lemmings.Add(new Lemming(_lemmingSprite, _startPosition));
            }

            // Update each Lemming's position in the level
            foreach (var lemming in _lemmings)
            {
                // If there's no ground below a lemming (check both corners), it is falling
                var bottomLeftOnGround = _level.GroundAtPosition(lemming.BottomLeft);
                var bottomRightOnGround = _level.GroundAtPosition(lemming.BottomRight);
                if (!bottomLeftOnGround && !bottomRightOnGround)
                {
                    lemming.Fall();
                }
                else
                {
                    // If not falling, a lemming is walking
                    var climbHeight = 0;
                    var found = false;

                    // Find the height of the ground in front of the lemming
                    // up to the maximum height a lemming can climb
                    while (!found && climbHeight <= Lemming.MAX_CLIMB_HEIGHT)
                    {
                        // The pixel 'in front' of a lemming will depend on the direction it's travelling
                        var positionInFront = _level.GroundAtPosition(lemming.CalculatePositionInFront(climbHeight));
                        if (!positionInFront)
                        {
                            lemming.ClimbWalk(climbHeight);
                            found = true;
                        }

                        climbHeight++;
                    }

                    if (!found)
                    {
                        // Turn the lemming around if the ground in front is too high to climb
                        lemming.TurnAround();
                    }
                }
            }
        }
    }
}
