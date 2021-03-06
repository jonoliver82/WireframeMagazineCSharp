﻿// **********************************************************************************
// Filename					- Breakout.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BreakoutPyGame.Models;
using Core;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BreakoutPyGame
{
    public class Breakout : MousePyGame
    {
        private const int WIDTH = 600;
        private const int HEIGHT = 800;
        private const int BALL_SIZE = 10;

        private const int MARGIN = 50;
        private const int BRICKS_X = 10;
        private const int BRICKS_Y = 5;
        private const int BRICK_WIDTH = (WIDTH - (2 * MARGIN)) / BRICKS_X;
        private const int BRICK_HEIGHT = 25;

        private readonly IRandom _random;

        private List<Brick> _bricks;
        private Ball _ball;

        private Bat _bat;

        public Breakout(IRandom random, ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _random = random;

            _bricks = new List<Brick>();
            _ball = new Ball(WIDTH / 2, HEIGHT / 2, BALL_SIZE, BALL_SIZE);
            _bat = new Bat(WIDTH / 2, HEIGHT - 50, 80, 12);

            Reset();
        }

        public override void Draw(Graphics g)
        {
            foreach (var brick in _bricks)
            {
                g.FillRectangle(brick.ColorBrush, brick.Rect);
                g.DrawLine(brick.HighlightPen, brick.BottomLeft, brick.TopLeft);
                g.DrawLine(brick.HighlightPen, brick.TopLeft, brick.TopRight);
            }

            g.FillRectangle(_bat.Brush, _bat.Rect);
            g.FillEllipse(_ball.Brush, _ball.Rect);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // When you have fast moving objects, like the ball, a good trick
            // is to run the update step several times per frame with tiny time steps.
            // This makes it more likely that collisions will be handled correctly
            for (int i = 0; i < 3; i++)
            {
                UpdateStep(i * 0.005);
            }
        }

        public override void MouseMove(int x, int y)
        {
            _bat.SetCenterX(x);

            // Clamp to screen width
            if (_bat.Left < 0)
            {
                _bat.Left = 0;
            }
            else if (_bat.Right > WIDTH)
            {
                _bat.Right = WIDTH;
            }
        }

        /// <summary>
        /// Reset bricks and ball.
        /// </summary>
        private void Reset()
        {
            // First, let's do bricks
            _bricks.Clear();

            var baseColor = Color.Pink;

            for (int x = 0; x < BRICKS_X; x++)
            {
                for (int y = 0; y < BRICKS_Y; y++)
                {
                    var brick = new Brick((x * BRICK_WIDTH) + MARGIN, (y * BRICK_HEIGHT) + MARGIN, BRICK_WIDTH - 1, BRICK_HEIGHT - 1);

                    var yDiff = brick.TopLeft.Y;
                    var highlight = Color.FromArgb(baseColor.R - yDiff, baseColor.G - yDiff, baseColor.B - yDiff);
                    brick.SetHighlight(highlight);

                    var color = Color.FromArgb(highlight.R - x, highlight.G - x, highlight.B - x);
                    brick.SetColor(color);

                    _bricks.Add(brick);
                }
            }

            // Now reset the ball
            _ball.Center = new Point(WIDTH / 2, HEIGHT / 2);
            _ball.Velocity.X = _random.Next(10) < 5 ? 100 : -100;
            _ball.Velocity.Y = 100;
        }

        private void UpdateStep(double difference)
        {
            var x = _ball.Center.X;
            var y = _ball.Center.Y;
            var vx = _ball.Velocity.X;
            var vy = _ball.Velocity.Y;

            if (_ball.Top > HEIGHT)
            {
                Reset();
                return;
            }

            // Update ball based on previous velocity
            x += (int)(vx * difference);
            y += (int)(vy * difference);
            _ball.Center = new Point(x, y);

            // Check for and resolve collisions
            if (_ball.Left < 0)
            {
                vx = Math.Abs(vx);
                _ball.Left = -_ball.Left;
            }
            else if (_ball.Right > WIDTH)
            {
                vx = -Math.Abs(vx);
                _ball.Right -= 2 * (_ball.Right - WIDTH);
            }

            if (_ball.Top < 0)
            {
                vy = Math.Abs(vy);
                _ball.Top *= -1;
            }

            if (_ball.Rect.IntersectsWith(_bat.Rect))
            {
                // Inverse the velocity of the ball
                vy = -Math.Abs(vy);
                vx = -Math.Abs(vx) + _random.Next(-20, 20);
            }
            else
            {
                // Find first collision
                for (int i = 0; i < _bricks.Count; i++)
                {
                    if (_ball.Rect.IntersectsWith(_bricks[i].Rect))
                    {
                        // Work out what side we collided on
                        var dx = (_ball.Center.X - _bricks[i].CenterX) / BRICK_WIDTH;
                        var dy = (_ball.Center.Y - _bricks[i].CenterY) / BRICK_HEIGHT;
                        if (Math.Abs(dx) > Math.Abs(dy))
                        {
                            vx = MathExtensions.CopySign(Math.Abs(vx), dx);
                        }
                        else
                        {
                            vy = MathExtensions.CopySign(Math.Abs(vy), dy);
                        }

                        _bricks.RemoveAt(i);

                        // Only remove one brick
                        break;
                    }
                }
            }

            // Write back updated position and velocity
            _ball.Center = new Point(x, y);
            _ball.Velocity = new Velocity(vx, vy);
        }
    }
}
