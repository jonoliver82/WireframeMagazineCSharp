// **********************************************************************************
// Filename					- Lemming.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace LemmingsPyGame.Models
{
    public class Lemming
    {
        public static int MAX_CLIMB_HEIGHT = 4;

        private const int WIDTH = 10;
        private const int HEIGHT = 20;
        private const int FALL_SPEED = 1;

        private Image _sprite;
        private Point _position;

        public Lemming(Image sprite, Point startPosition)
        {
            _sprite = sprite;
            _position = startPosition;

            SpeedX = 1;
        }

        // Properties used to determine if the bottom of the lemming is on ground or not
        public Point BottomLeft => new Point(_position.X, _position.Y + HEIGHT);

        public Point BottomRight => new Point(_position.X + (WIDTH - 1), _position.Y + HEIGHT);

        public int SpeedX { get; private set; }

        public void Draw(Graphics g)
        {
            g.DrawImage(_sprite, _position);
        }

        public void Fall()
        {
            _position = new Point(_position.X, _position.Y + FALL_SPEED);
        }

        public Point CalculatePositionInFront(int height)
        {
            if (SpeedX == 1)
            {
                return new Point(_position.X + WIDTH, _position.Y + (HEIGHT - 1) - height);
            }
            else
            {
                return new Point(_position.X - 1, _position.Y + (HEIGHT - 1) - height);
            }
        }

        public void ClimbWalk(int climbHeight)
        {
            // Walk and rise up to the new ground level
            _position = new Point(_position.X + SpeedX, _position.Y - climbHeight);
        }

        public void TurnAround()
        {
            SpeedX *= -1;
        }
    }
}
